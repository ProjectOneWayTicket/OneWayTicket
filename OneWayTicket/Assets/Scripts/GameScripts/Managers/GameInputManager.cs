using PACE.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Managers
{
    public class GameInputManager : InputManager
    {
        //The main player listener. Controls player movement and actions
        IInputListener _playerListener;
        IInputListener _gameManagerListener;

        public GameInputManager(IInputListener playerListener, IInputListener gameManagerListener)
        {          
            _playerListener = playerListener;
            Listeners.Add(_playerListener);
            _gameManagerListener = gameManagerListener;
            Listeners.Add(_gameManagerListener);
        }

        public override void SetInputState(InputState state)
        {
            switch (state)
            {
                case InputState.InGameMenu:
                    InGameMenu();
                    break;
                case InputState.PlayerControl:
                    PlayerControl();
                    break;
                default:
                    Debug.Log("Error: No set input state logic for the InputState: " + state.ToString());
                    break;
            }
        }

        private void InGameMenu()
        {
            _playerListener.SetActive(false);
        }
        private void PlayerControl()
        {
            _playerListener.SetActive(true);
        }

    }
}
