using PACE.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GameGUI
{
    public class InGameGUI : BaseBehaviour, IInGameGUI
    {
        private class ItemHoverLabel
        {
            public string Label;
            public Vector2 Position;
            public ItemHoverLabel(string label, Vector2 position)
            {
                Label = label;
                Position = position;
            }
        }

        private class InteractionMenu
        {
            public string Label;
            public Vector2 Position;
            public InteractionMenu(string label, Vector2 position)
            {
                Label = label;
                Position = position;
            }
        }

        private bool _isActive = true;
        private ItemHoverLabel _itemHoverLabel;
        private InteractionMenu _interactionMenu;

        void Update()
        {
            _itemHoverLabel = null;
        }

        public void DrawGUI()
        {
            if (!_isActive)
                return;

            if (_itemHoverLabel != null)
                GUI.Button(new Rect(_itemHoverLabel.Position.x - 100, Screen.height - _itemHoverLabel.Position.y - 100, 200, 100), _itemHoverLabel.Label);

            if(_interactionMenu != null)
            {
                GUI.Button(new Rect(_interactionMenu.Position.x - 25, Screen.height - _interactionMenu.Position.y - 25, 50, 50), _interactionMenu.Label);
            }
        }

        public void UpdateItemHoverLabel(string label, Vector3 position)
        {
            _itemHoverLabel = new ItemHoverLabel(label, position);
        }

        public void UpdateInteractionMenu(string label, Vector3 position)
        {
            _interactionMenu = new InteractionMenu(label, position);
        }

        public void CloseInteractionMenu()
        {
            _interactionMenu = null;
        }

        public void SetActive(bool active) { _isActive = active; }
        public bool IsActive() { return _isActive; }

    }
}
