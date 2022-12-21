using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsSwitch : MonoBehaviour
{
    [SerializeField] private GameObject _mobileControlsCanvas;
    [SerializeField] private GameObject _defaultControlsCanvas;

    private void Start()
    {
        if (Application.isMobilePlatform)
        {
            _mobileControlsCanvas.SetActive(true);
        }

        _defaultControlsCanvas.SetActive(true);
    }
}