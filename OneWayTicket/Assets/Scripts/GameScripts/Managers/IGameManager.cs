using GameGUI;
using PACE.Framework.GameManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Managers
{
    public interface IGameManager : IPACEGameManager
    {
        IInGameGUI GetInGameGUIInstance();
    }
}
