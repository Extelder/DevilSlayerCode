using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGameobjectActiveByKey : MonoBehaviour
{
    [SerializeField] private KeyCode _keyCode;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private PlayerCursorLock _playerCursorLock;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(_keyCode))
        {
            _playerCursorLock.enabled = !_playerCursorLock.enabled;
            _gameObject.SetActive(!_gameObject.activeSelf);
        }
    }
}