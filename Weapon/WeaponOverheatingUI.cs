using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponOverheatingUI : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private WeaponOverheating _weaponOverheating;

    private void OnEnable()
    {
        _weaponOverheating.CurrentOverheatValueChange += OnOverheatingValueChanged;
    }

    private void OnDisable()
    {
        _weaponOverheating.CurrentOverheatValueChange -= OnOverheatingValueChanged;
    }

    public void OnOverheatingValueChanged(float value)
    {
        _text.text = Mathf.RoundToInt(value).ToString();
    }
}