using PACE.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GameGUI
{
    public interface IInGameGUI : IGUI
    {
        void UpdateItemHoverLabel(string label, Vector3 position);
    }
}
