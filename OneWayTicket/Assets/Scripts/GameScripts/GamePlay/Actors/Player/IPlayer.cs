using UnityEngine;
using System.Collections;
using PACE.IO;

namespace GamePlay.Actors.Player
{
    public interface IPlayer
    {
        IInputListener GetInputListener();
    }
}
