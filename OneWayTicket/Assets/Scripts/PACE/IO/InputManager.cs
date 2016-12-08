
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace PACE.IO
{
    public class InputManager : IInputManager
    {     
        private List<IInputListener> _listeners;
        protected List<IInputListener> Listeners { get { return _listeners; } set { if(value is List<IInputListener>) _listeners = value; } }

        protected IInputState _inputState;

        public InputManager()
        {
            _listeners = new List<IInputListener>();
            _inputState = null;
        }

        public void Update()
        {
            //Reset the keys on each listener
            foreach (IInputListener listener in _listeners)
            {
                if (listener.IsActive())
                    listener.ResetKeys();
            }

            //Loop through each input key and send info to listeners
            foreach (InputKey key in Enum.GetValues(typeof(InputKey)))
            {
                if (Input.GetButtonDown(key.ToDescription()))
                {
                    foreach (IInputListener listener in _listeners)
                    {

                        if (listener.IsActive())
                            listener.KeyPressed(key);
                    }
                }
            }
        }

        //Get Mouse x-y position
        public Vector2 GetMousePosition()
        {
            return Input.mousePosition;
        }

        //Get a ray from the current cursor position
        public Ray GetRayFromMousePosition()
        {
            return Camera.main.ScreenPointToRay(GetMousePosition());
        }
    }
}
