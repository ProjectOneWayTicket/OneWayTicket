using PACE.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GameGUI
{
    public class InGameMenuGUI : BaseBehaviour, IInGameMenuGUI
    {
        private bool _isActive = true;

        void Update()
        {
            if (!_isActive)
                return;
        }

        public void DrawGUI()
        {
            GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100));
            if(GUI.Button(new Rect(0, 0, 200, 100), "String_ExitToWindows".Localize()))
            {
                GetGameManager().ExitGame();
            };

            GUI.EndGroup();
        }

        public void SetActive(bool active) { _isActive = active; }
        public bool IsActive() { return _isActive; }

    }
}
