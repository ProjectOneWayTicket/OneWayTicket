using UnityEngine;
using System.Collections;

namespace GamePlay.Actors.Player
{
    public class PlayerAnimation : IPlayerAnimation
    {
        private Animator _playerAnimator;

        private static readonly string playerStateKey = "PlayerState";

        public PlayerAnimation(Animator playerAnimator)
        {
            _playerAnimator = playerAnimator;
        }
        public void Update(PlayerState playerState)
        {
            _playerAnimator.SetInteger(playerStateKey, (int) playerState);
        }
    }
}
