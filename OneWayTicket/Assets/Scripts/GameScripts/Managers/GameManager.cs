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
using Gameplay.Actors;
using GamePlay.Interactable;

namespace Managers
{
    //Static GameManager Class - This is the master class for the entire game.
    public class GameManager : PACEGameManager, IGameManager
    {
        public static GameManager Instance;

        private GameState _gameState;
        private IPlayer _player;
        private IInGameGUI _inGameGUI;
        private IInGameMenuGUI _inGameMenuGUI;
        private IInputController _inputController;

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
            _inGameMenuGUI = gameObject.AddComponent<InGameMenuGUI>();
            _inGameGUI.SetActive(true);
            _inGameMenuGUI.SetActive(false);

            //Create player
            GameObject player = Instantiate(Resources.Load("Actors/Player/Player", typeof(GameObject))) as GameObject;
            _player = player.GetComponent<Player>();

            //Setup the Input Manager
            _inputController = new InputController();
            _inputManager = new GameInputManager(_player.GetInputListener(), _inputController.GetInputListener());

            //Initialize the game state
            SetGameState(GameState.GamePlay);
        }

        void Update()
        {
            UpdateFromState(_gameState);
            _inputManager.Update();
        }

        void OnGUI()
        {
            if(_inGameGUI != null && _inGameGUI.IsActive())
                _inGameGUI.DrawGUI();
            if (_inGameMenuGUI != null && _inGameMenuGUI.IsActive())
                _inGameMenuGUI.DrawGUI();
        }

        //Call the appropriate update function for the current state
        private void UpdateFromState(GameState state)
        {
            switch (state)
            {
                case GameState.InGameMenu:
                    InGameMenu();
                    break;
                case GameState.GamePlay:
                    GamePlay();
                    break;
                default:
                    Debug.Log("Error: No update logic for the GameState: " + state.ToString());
                    break;
            }
        }

        private void SetGameState(GameState state)
        {
            _gameState = state;
            switch (state)
            {
                case GameState.InGameMenu:
                    _inGameGUI.SetActive(false);
                    _inGameMenuGUI.SetActive(true);
                    _inputManager.SetInputState(InputState.InGameMenu);
                    PauseGame();
                    break;
                case GameState.GamePlay:
                    _inGameGUI.SetActive(true);
                    _inGameMenuGUI.SetActive(false);
                    _inputManager.SetInputState(InputState.PlayerControl);
                    ResumeGame();
                    break;
                default:
                    Debug.Log("Error: No set game state logic for the GameState: " + state.ToString());
                    break;
            }
        }

        public GameState GetGameState()
        {
            return _gameState;
        }

        private void PauseGame()
        {
            ActorTimeManager.Instance.TimeManager.Pause();
        }

        private void ResumeGame()
        {
            ActorTimeManager.Instance.TimeManager.Resume();
        }

        private void GamePlay()
        {
            if (_inputController.IsKeyPressed(InputKey.InGameMenu))
                SetGameState(GameState.InGameMenu);
        }

        private void InGameMenu()
        {
            if (_inputController.IsKeyPressed(InputKey.InGameMenu))
                SetGameState(GameState.GamePlay);
        }

        public IInGameGUI GetInGameGUIInstance()
        {
            return _inGameGUI;
        }

        public void ExitGame()
        {
            if (Application.isEditor)
            {
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #endif
            }
            else
            {
                Application.Quit();
            }
        }

    }
}
