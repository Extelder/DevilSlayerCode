using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private WeaponFire[] _allWeapons;
    [SerializeField] private WeaponFire _currentWeaponFire;

    private WeaponFire _nextWeapon;

    public static WeaponSwitcher Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }

    private void Start() =>
        ActivateCurrentWeapon();

    public void DisactivateAllWeapons()
    {
        for (int i = 0; i < _allWeapons.Length; i++)
        {
            _allWeapons[i].gameObject.SetActive(false);
        }
    }

    public void ActivateCurrentWeapon()
    {
        DisactivateAllWeapons();
        _currentWeaponFire.gameObject.SetActive(true);
    }

    public void ActivateNextWeapon(WeaponFire weaponFire)
    {
        _nextWeapon = weaponFire;
        if (_currentWeaponFire.CanFire)
        {
            _currentWeaponFire = _nextWeapon;
            ActivateCurrentWeapon();
        }
    }
}