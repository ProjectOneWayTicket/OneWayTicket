using PACE.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Managers
{
    public class GlobalInputManager : InputManager
    {
        //The main player listener. Controls player movement and actions
        IInputListener _playerListener;

        public GlobalInputManager(IInputListener playerListener)
        {          
            _playerListener = playerListener;
            Listeners.Add(playerListener);
        }

        public void Roaming()
        {
            _playerListener.SetActive(true);
        }

    }
}
