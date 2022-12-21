using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitComboUI : MonoBehaviour
{
    [SerializeField] private HitCombo _hitCombo;
    [SerializeField] private Text _currentComboValueText;
    [SerializeField] private Text _currentComboMultiplyText;
    [SerializeField] private Text _currentTimeToDisactivateComboText;

    private void OnEnable()
    {
        _hitCombo.CurrentComboMultiplyChanged += OnCurrentComboMultyplyChanged;
        _hitCombo.CurrentTimeToDisactivateComboChanged += OnCurrentTimeToDisactivateComboChanged;
    }

    private void OnDisable()
    {
        _hitCombo.CurrentComboMultiplyChanged -= OnCurrentComboMultyplyChanged;
        _hitCombo.CurrentTimeToDisactivateComboChanged -= OnCurrentTimeToDisactivateComboChanged;
    }

    public void OnCurrentComboMultyplyChanged(int value)
    {
        SetAllTextsEnable(true);
        SetTextValue(_currentComboMultiplyText, value);
    }


    public void OnCurrentTimeToDisactivateComboChanged(float value)
    {
        SetAllTextsEnable(true);
        SetTextValue(_currentTimeToDisactivateComboText, Convert.ToInt32(value));
        if (value <= 0)
        {
            SetAllTextsEnable(false);
        }
    }

    private void SetTextValue(Text text, object value)
    {
        text.text = value.ToString();
    }

    private void SetAllTextsEnable(bool value)
    {
        _currentComboMultiplyText.enabled = value;
        _currentComboValueText.enabled = value;
        _currentTimeToDisactivateComboText.enabled = value;
    }
}