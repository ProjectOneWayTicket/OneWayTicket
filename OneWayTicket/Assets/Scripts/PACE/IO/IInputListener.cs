using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PACE.IO
{
    public interface IInputListener
    {
        void ResetKeys();
        void KeyPressed(InputKey key);
        void SetActive(bool active = true);
        bool IsActive();
    }
}
