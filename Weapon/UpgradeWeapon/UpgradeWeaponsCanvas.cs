using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeWeaponsCanvas : MonoBehaviour
{
    [SerializeField] private PlayerCursorLock _playerCursorLock;
    [SerializeField] private GameObject _canvas;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (_playerCursorLock != null)
                _playerCursorLock.enabled = !_playerCursorLock.enabled;
            ActivateCanvas();
        }
    }

    public void ActivateCanvas()
    {
        _canvas.SetActive(!_canvas.activeSelf);
    }
}