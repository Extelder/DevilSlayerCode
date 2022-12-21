using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootableButton : MonoBehaviour,IShootInteractable
{
    public UnityEvent OnInteract;

    public void Interact()
    {
        OnInteract?.Invoke();
    }
}