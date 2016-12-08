using System;
using System.Collections.Generic;
using System.Linq;

namespace PACE.IO
{
    public class InputListener : IInputListener
    {
        private bool _isActive = true;
        protected Dictionary<InputKey, bool> keyPressed;

        public InputListener()
        {
            keyPressed = new Dictionary<InputKey, bool>();
            foreach (InputKey key in Enum.GetValues(typeof(InputKey)))
            {
                keyPressed[key] = false;
            }
        }
        public void ResetKeys()
        {
            foreach (InputKey key in keyPressed.Keys.ToList())
            {
                keyPressed[key] = false;
            }
        }

        public void KeyPressed(InputKey key)
        {
            keyPressed[key] = true;
        }
        public void SetActive(bool active)
        {
            ResetKeys();
            _isActive = active;
        }

        public bool IsActive()
        {
            return _isActive;
        }
    }
}
