using GameGUI;
using GamePlay.Actors.Player;
using Managers;
using PACE.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using GameGUI;
using PACE.Framework.GameManager;

namespace Managers
{
    //Static GameManager Class - This is the master class for the entire game.
    public class GameManager : PACEGameManager, IGameManager
    {
        public static GameManager Instance;

        private GameState _gameState;
        private IPlayer _player;
        private IInGameGUI _inGameGUI;

        //This method initializes the game on startup
        protected override void InitializeGame()
        {
            //On awake, set this instance as the static GameManager. There can be only one!
            if (Instance != null)
                Destroy(Instance);
            else
                Instance = this;
            DontDestroyOnLoad(this);

            //Create InGameGUI
            _inGameGUI = gameObject.AddComponent<InGameGUI>();

            //Create player
            GameObject player = Instantiate(Resources.Load("Actors/Player/Player", typeof(GameObject))) as GameObject;
            _player = player.GetComponent<Player>();

            //Setup the Input Manager
            _inputManager = new GlobalInputManager(_player.GetInputListener());

            //Initialize the game state
            _gameState = GameState.Roaming;
        }

        void Update()
        {
            UpdateFromState(_gameState);
            _inputManager.Update();
        }

        void OnGUI()
        {
            if(_inGameGUI != null)
                _inGameGUI.DrawGUI();
        }

        //Call the appropriate update function for the current state
        private void UpdateFromState(GameState state)
        {
            switch (state)
            {
                case GameState.Roaming:
                    Roaming();
                    break;
                case GameState.Inspecting:
                    Inspecting();
                    break;
            }
        }

        private void Roaming()
        {

        }

        private void Inspecting()
        {

        }


        public IInGameGUI GetInGameGUIInstance()
        {
            return _inGameGUI;
        }

    }
}
