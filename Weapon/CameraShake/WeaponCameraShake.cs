using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCameraShake : CameraShake
{
    [SerializeField] private WeaponAiming _aiming;

    private const float _aimingValue = 2f;
    
    public override void Shake(float value)
    {
        if (_aiming.Aiming)
            value = _aimingValue;
        base.Shake(value);
    }
}