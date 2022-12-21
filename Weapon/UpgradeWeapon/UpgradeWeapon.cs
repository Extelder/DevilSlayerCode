using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeWeapon : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private WeaponFire _weaponFire;
    [SerializeField] private WeaponCooldown _weaponCooldown;
    [SerializeField] private float _damageUpgradeValue;
    [SerializeField] private float _cooldownUpgradeValue;
    [SerializeField] private int _damageUpgradeCost;
    [SerializeField] private int _cooldownUpgradeCost;
    [SerializeField] private Text _damageUpgradeText;
    [SerializeField] private Text _cooldownUpgradeText;
    [SerializeField] private Text _damageText;
    [SerializeField] private Text _cooldwonText;

    private void OnEnable()
    {
        _damageUpgradeText.text = _damageUpgradeCost.ToString();
        _cooldownUpgradeText.text = _cooldownUpgradeCost.ToString();
        _damageText.text = _weaponFire.GetDamage().ToString();
        _cooldwonText.text = _weaponCooldown.TimeMultiplayer.ToString();
    }

    public void UpgradeDamage()
    {
        _wallet.SpendCoins(_damageUpgradeCost, (() =>
                {
                    _weaponFire.AddToDamageValue(_damageUpgradeValue);
                    _damageText.text = _weaponFire.GetDamage().ToString();
                }
            ));
    }

    public void UpgradeCooldown()
    {
        _wallet.SpendCoins(_cooldownUpgradeCost, (() =>
                {
                    _weaponCooldown.AddToTimeMultiplyValue(_cooldownUpgradeValue);
                    _cooldwonText.text = _weaponCooldown.TimeMultiplayer.ToString();
                }
            ));
    }
}