using UnityEngine;
using System.Collections;

namespace PACE.Framework.Time
{
    public interface ITimeManager
    {
        float GetDeltaTime();
        float GetFixedDeltaTime();
        void Pause();
        void Resume();
    }
}
