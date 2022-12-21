using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponCooldownUI : MonoBehaviour
{
    [SerializeField] private Image _cooldownBarFirstPart;
    [SerializeField] private Image _cooldownBarSecondPart;

    public void CooldownBegined()
    {
        SetFullBarEnable(true);
    }

    public void CooldownUpdated(float value)
    {
        _cooldownBarFirstPart.fillAmount = value / 100;
        _cooldownBarSecondPart.fillAmount = value / 100;
        if (value <= 0)
        {
            SetFullBarEnable(false);
        }
    }

    private void SetFullBarEnable(bool value)
    {
        _cooldownBarFirstPart.enabled = value;
        _cooldownBarSecondPart.enabled = value;
    }
}