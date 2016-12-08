using PACE.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PACE.Framework.GameManager
{
    public interface IPACEGameManager
    {
        IInputManager GetInputManagerInstance();
    }
}
