using UnityEngine;
using System.Collections;
using GameGUI;
using Managers;
using PACE.IO;

//This is the base behaviour which all game objects inheret from
namespace PACE.Framework
{
    public class BaseBehaviour : MonoBehaviour
    {
        public IGameManager GetGameManager()
        {
            return Managers.GameManager.Instance;
        }

        public IInGameGUI GetInGameGUI()
        {
            return GetGameManager().GetInGameGUIInstance();
        }

        public IInputManager GetInputManager()
        {
            return GetGameManager().GetInputManagerInstance();
        }

    }
}
