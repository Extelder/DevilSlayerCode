using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Text _maxHealthValueText;
    [SerializeField] private Text _currentHealthValueText;
    [SerializeField] private Image _image;
    [SerializeField] private Health _health;

    private float _oneProcentFromMaxHealthValue;

    private void Awake()
    {
        _oneProcentFromMaxHealthValue = _health.MaxValue / 100f;
        _maxHealthValueText.text = _health.MaxValue.ToString();
        _currentHealthValueText.text = _health.MaxValue.ToString();
    }

    private void OnEnable()
    {
        _health.OnCurrentHealthValueChaneged += OnHealthValueChanged;
    }

    private void OnDisable()
    {
        _health.OnCurrentHealthValueChaneged -= OnHealthValueChanged;
    }

    private void OnHealthValueChanged(float value)
    {
        _image.fillAmount = value / _oneProcentFromMaxHealthValue / 100;
        _currentHealthValueText.text = value.ToString();
    }
}