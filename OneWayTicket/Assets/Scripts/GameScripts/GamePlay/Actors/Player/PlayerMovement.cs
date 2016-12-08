using UnityEngine;
using System.Collections;
using Pathfinding;
using PACE.Framework.Time;

namespace GamePlay.Actors.Player
{
    public class PlayerMovement : IPlayerMovement
    {
        private Seeker _seeker;
        private CharacterController _characterController;
        private GameObject _playerObject;
        private TimeManager _timeManager;
        private Vector3 _navTarget;

        private Vector3 targetPoint;
        public Path path;
        public float speed = 200;
        public float nextWaypointDistance = 1;
        private int currentWaypoint = 0;
        public float repathRate = 0.1f;
        private float lastRepath = -9999;

        public PlayerMovement(Seeker seeker, CharacterController characterController, GameObject playerObject, TimeManager timeManager)
        {
            _seeker = seeker;
            _characterController = characterController;
            _playerObject = playerObject;
            _timeManager = timeManager;
            _navTarget = Vector3.zero;
        }

        public void OnPathComplete(Path p)
        {
            p.Claim(this);
            if (!p.error)
            {
                if (path != null) path.Release(this);
                path = p;
                targetPoint = p.vectorPath[p.vectorPath.Count - 1];
                //Reset the waypoint counter
                currentWaypoint = 0;
            }
            else {
                p.Release(this);
                Debug.Log("Oh noes, the target was not reachable: " + p.errorLog);
            }
        }

        public void Update()
        {
            if (Time.time - lastRepath > repathRate && _seeker.IsDone())
            {
                lastRepath = Time.time + Random.value * repathRate * 0.5f;
                _seeker.StartPath(_playerObject.transform.position, _navTarget, OnPathComplete);
            }
            if (path == null)
            {
                //We have no path to move after yet
                return;
            }
            if (currentWaypoint > path.vectorPath.Count) return;
            if (currentWaypoint == path.vectorPath.Count)
            {
                Debug.Log("End Of Path Reached");
                currentWaypoint++;
                return;
            }
            //Direction to the next waypoint
            Vector3 dir = (path.vectorPath[currentWaypoint] - _playerObject.transform.position).normalized;
            dir *= (speed * _timeManager.GetDeltaTime());// * Time.deltaTime;
                         //transform.Translate (dir);
            _characterController.SimpleMove(dir);

            if(Vector3.Distance(_playerObject.transform.position, path.vectorPath[currentWaypoint]) > 1)
            {
                Quaternion rotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
                _playerObject.transform.rotation = Quaternion.Lerp(_playerObject.transform.rotation, rotation, _timeManager.GetDeltaTime() * 10);
            }

            //if (Vector3.Distance (transform.position,path.vectorPath[currentWaypoint]) < nextWaypointDistance) {
            if ((_playerObject.transform.position - path.vectorPath[currentWaypoint]).sqrMagnitude < nextWaypointDistance * nextWaypointDistance)
            {
                currentWaypoint++;
                
                return;
            }
        }

        public void UpdateNavTarget(Vector3 target)
        {
            _navTarget = target;
        }

        public bool IsAtDestination()
        {
            return targetPoint != null && _playerObject != null ? Vector3.Distance(_playerObject.transform.position, _navTarget) < 1 : false;
        }
    }
}
