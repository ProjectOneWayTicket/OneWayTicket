using UnityEngine;

namespace PACE.IO
{
    public interface IInputManager
    {
        void Update();
        Vector2 GetMousePosition();
        Ray GetRayFromMousePosition();
    }
}
