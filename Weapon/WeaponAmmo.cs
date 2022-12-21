using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAmmo : MonoBehaviour
{
    [SerializeField] private int _ammoInClip;
    [SerializeField] private int _maxAmmoInClip;
    [SerializeField] private int _allAmmo;

    private int ammoToReload = 0;

    public event Action Reload;

    public void SpendAmmo()
    {
        if(_ammoInClip > 0)
         _ammoInClip -= 1;
    }

    public void ClearAmmoInClip()
    {
        _ammoInClip = 0;
    }

    public void EnterAmmoInClip()
    {
        if (_allAmmo >= _maxAmmoInClip)
        {
            _ammoInClip = _maxAmmoInClip;
            _allAmmo -= _maxAmmoInClip;
        }
        else
        {
            _ammoInClip += _allAmmo;
            _allAmmo = 0;
        }
    }

    private void CheckToReload()
    {
        if(_allAmmo <= 0)
            return;
        if (_ammoInClip < 0)
            Reload?.Invoke();
    }
}