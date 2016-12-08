using PACE.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GameGUI
{
    public interface IInGameMenuGUI : IGUI
    {
        void SetActive(bool active);
        bool IsActive();
    }
}
