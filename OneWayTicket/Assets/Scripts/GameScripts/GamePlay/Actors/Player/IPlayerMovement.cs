using UnityEngine;
using System.Collections;

namespace GamePlay.Actors.Player
{
    public interface IPlayerMovement
    {
        void Update();
        void UpdateNavTarget(Vector3 target);
        bool IsAtDestination();
    }
}
