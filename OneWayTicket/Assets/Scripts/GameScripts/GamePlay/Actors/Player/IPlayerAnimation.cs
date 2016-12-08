using UnityEngine;
using System.Collections;

namespace GamePlay.Actors.Player
{
    public interface IPlayerAnimation
    {
        void Update(PlayerState playerState);
    }
}

