using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursorLock : MonoBehaviour
{
    private void OnEnable() => Disable();

    private void OnDisable() => Enable();

    public void Enable()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Disable()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
