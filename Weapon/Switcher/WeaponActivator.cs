using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponActivator : MonoBehaviour
{
    [SerializeField] private KeyCode _keyCode;
    [SerializeField] private WeaponFire _weaponFire;

    private WeaponSwitcher _weaponSwitcher;
    
    private void Start()
    {
        _weaponSwitcher = WeaponSwitcher.Instance;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(_keyCode))
        {
            _weaponSwitcher.ActivateNextWeapon(_weaponFire);
        }
    }
}
