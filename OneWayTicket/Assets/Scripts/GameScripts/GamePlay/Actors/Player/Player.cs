using UnityEngine;
using PACE.Framework;
using Gameplay.Actors;
using PACE.IO;
using Enums;
using Managers;
using PACE.Framework.GameManager;
using GamePlay.Interactable;

namespace GamePlay.Actors.Player
{
    public class Player : BaseBehaviour, IPlayer
    {
        private IPlayerInteraction _playerInteraction;
        private IPlayerMovement _playerMovement;
        private IPlayerAnimation _playerAnimation;
        private IInputController _playerInput;
        private Seeker _seeker;
        private CharacterController _characterController;
        private PlayerState _playerState;
        private IInteractable _selectedInteractable = null;

        private bool isInteractableSelected { get { return _selectedInteractable != null; } }
 
        private float _mouseRayCastDistance = 1000f;

        public Player()
        {
        }

        //Initialize the player object
        void Awake()
        {
            _seeker = GetComponent<Seeker>();
            _characterController = GetComponent<CharacterController>();

            _playerInteraction = new PlayerInteraction();
            _playerMovement = new PlayerMovement(_seeker, _characterController, gameObject, ActorTimeManager.Instance.TimeManager);
            _playerAnimation = new PlayerAnimation(gameObject.GetComponentInChildren<Animator>());
            _playerInput = new PlayerInput();

            _playerState = PlayerState.Idle;
        }

        // Update is called once per frame
        void Update()
        {
            UpdateFromGameState(GetGameManager().GetGameState());
            UpdateFromState(_playerState);
        }

        public IInputListener GetInputListener()
        {
            return _playerInput.GetInputListener();
        }

        private void SetPlayerState(PlayerState state)
        {
            _playerState = state;
        }

        private void UpdateFromGameState(GameState state)
        {
            switch (state)
            {
                case GameState.GamePlay:
                    GamePlay();
                    break;
            }
        }

        //Call the appropriate update function for the current state
        private void UpdateFromState(PlayerState state)
        {
            switch (state)
            {
                case PlayerState.Idle:
                    Idle();
                    break;
                case PlayerState.Walking:
                    Walking();
                    break;
            }
        }

        private void GamePlay()
        {
            CheckInteractableSelected();
            if(!isInteractableSelected)
                UpdateItemHoverLabelGUI();
            _playerAnimation.Update(_playerState);
        }

        //The player is not moving and has no current commands
        private void Idle()
        {
            if(UpdateNavTarget())
                SetPlayerState(PlayerState.Walking);
        }

        //The player is walking towards a destination
        private void Walking()
        {
            _playerMovement.Update();
            UpdateNavTarget();
            if (_playerMovement.IsAtDestination())
            {
                _playerState = PlayerState.Idle;
            }
        }

        private bool CheckInteractableSelected()
        {
            if(_playerInput.IsKeyPressed(InputKey.RightMouseButton))
            {
                RaycastHit hit;
                if (GetInteractablesRaycastFromMouse(out hit))
                {
                    if (hit.collider && hit.collider.gameObject.GetComponent<IInteractable>() != null)
                    {
                        if (hit.collider.gameObject.GetComponent<IInteractable>().IsActive())
                        {
                            _selectedInteractable = hit.collider.gameObject.GetComponent<IInteractable>();
                            GetInGameGUI().UpdateInteractionMenu(hit.collider.gameObject.GetComponent<IInteractable>().GetLabel(), GetInputManager().GetMousePosition());
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        //Check to see if the left mouse is clicked and if a new movement target has been selected
        private bool UpdateNavTarget()
        {
            if (!_playerInput.IsKeyPressed(InputKey.LeftMouseButton))
                return false;

            RaycastHit hit;
            if (GetInteractablesRaycastFromMouse(out hit))
            {
                _playerMovement.UpdateNavTarget(hit.point);
                return true;
            }
            return false;
        }

        private void UpdateItemHoverLabelGUI()
        {
            RaycastHit hit;
            if (GetInteractablesRaycastFromMouse(out hit))
            {
                if (hit.collider && hit.collider.gameObject.GetComponent<IInteractable>() != null)
                {
                    if (hit.collider.gameObject.GetComponent<IInteractable>().IsActive())
                    {
                        GetInGameGUI().UpdateItemHoverLabel(hit.collider.gameObject.GetComponent<IInteractable>().GetLabel(), GetInputManager().GetMousePosition());
                    }
                }
            }
        }

        private bool GetInteractablesRaycastFromMouse(out RaycastHit hit)
        {
            LayerMask noObstacleLayerMask = LayerMaskExtensions.LayerMaskExcludingLayers(Layer.NavObstacles);
            Ray ray = GetInputManager().GetRayFromMousePosition();
            return Physics.Raycast(ray, out hit, _mouseRayCastDistance, noObstacleLayerMask);
        }

    }
}
