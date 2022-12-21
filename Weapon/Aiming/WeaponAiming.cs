using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAiming : MonoBehaviour
{
    [SerializeField] private Vector3 AimingPosition;
    [SerializeField] private CameraFov _cameraFov;

    public bool Aiming { get; private set; }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
            EnableAiming();

        if (Input.GetKeyUp(KeyCode.Mouse1))
            DisableAiming();
    }

    private void EnableAiming()
    {
        Aiming = true;
        _cameraFov.SetWithoutLerpFov(30f);
        _cameraFov.enabled = false;
        transform.localPosition = AimingPosition;
    }

    private void DisableAiming()
    {
        Aiming = false;
        _cameraFov.SetWithoutLerpFov(_cameraFov.DefaultFov);
        _cameraFov.enabled = true;
        transform.localPosition = new Vector3(0, 0, 0);
    }
}