using UnityEngine;
using System.Collections;

namespace GamePlay.Interactable
{
    public interface IInteractable
    {
        string GetLabel();
        bool IsActive();
        bool CanLookAt();
        void Look();
    }
}