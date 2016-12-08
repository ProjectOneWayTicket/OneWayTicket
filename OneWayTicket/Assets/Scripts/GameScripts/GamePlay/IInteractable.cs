using UnityEngine;
using System.Collections;

public interface IInteractable
{
    string GetLabel();
    bool IsActive();
    bool CanLook();
    void Look();
}
