using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAutoFire : MonoBehaviour
{
    [SerializeField] private WeaponFire _weaponFire;
    [SerializeField] private WeaponAnimator _weaponAnimator;
    
    private void Update()
    {
        RaycastHit hit = _weaponFire.PerformRaycastHit();
        if(hit.collider != null && hit.collider.TryGetComponent(out HitBox hitBox))
        {
            _weaponAnimator.FireAnimation();
        }
    }
}
