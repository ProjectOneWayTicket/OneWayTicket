using UnityEngine;
using System.Collections;

namespace PACE.Framework.Time
{
    public class TimeManager : ITimeManager
    {
        //Controls the scale of the delta time
        private float _timeScale = 1.0f;
        private bool _isPaused = false;

        public float GetDeltaTime()
        {
            return _isPaused ? 0.0f : UnityEngine.Time.deltaTime * _timeScale;
        }

        public float GetFixedDeltaTime()
        {
            return _isPaused ? 0.0f : UnityEngine.Time.fixedDeltaTime * _timeScale;
        }

        public void Pause()
        {
            _isPaused = true;
        }

        public void Resume()
        {
            _isPaused = false;
        }
    }
}
