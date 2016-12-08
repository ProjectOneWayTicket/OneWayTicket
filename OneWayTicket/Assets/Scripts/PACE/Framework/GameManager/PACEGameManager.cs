using GameGUI;
using PACE.Framework;
using PACE.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PACE.Framework.GameManager
{
    public class PACEGameManager : BaseBehaviour, IPACEGameManager
    {
        protected IInputManager _inputManager;

        void Awake()
        {
            InitializeGame();
        }

        protected virtual void InitializeGame() { }

        private void Update()
        {
            _inputManager.Update();
        }

        public IInputManager GetInputManagerInstance()
        {
            return _inputManager;
        }

    }
}
