using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PACE.IO
{
    public interface IInputController
    {
        IInputListener GetInputListener();
        bool IsKeyPressed(InputKey key);
    }
}
