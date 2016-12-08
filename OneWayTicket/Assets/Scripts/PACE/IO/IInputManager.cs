using Managers;
using UnityEngine;

namespace PACE.IO
{
    public interface IInputManager
    {
        void Update();
        void SetInputState(InputState state);
        Vector2 GetMousePosition();
        Ray GetRayFromMousePosition();
    }
}
