using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PACE.IO
{
    public class InputController : InputListener, IInputController
    {
        public IInputListener GetInputListener()
        {
            return this;
        }

        public bool IsKeyPressed(InputKey key)
        {
            if (!IsActive())
                return false;

            return keyPressed[key];
        }
    }
}
