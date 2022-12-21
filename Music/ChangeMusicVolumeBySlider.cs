using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMusicVolumeBySlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private WeaponAnimator[] _weaponAnimators;


    private void OnEnable()
    {
        for (int i = 0; i < _weaponAnimators.Length; i++)
        {
            _weaponAnimators[i].Stopped = true;
        }

        _slider.onValueChanged.AddListener((OnSlierValueChanged));
    }

    private void OnDisable()
    {
        for (int i = 0; i < _weaponAnimators.Length; i++)
        {
            _weaponAnimators[i].Stopped = false;
        }

        _slider.onValueChanged.RemoveListener(OnSlierValueChanged);
    }

    private void OnSlierValueChanged(float value)
    {
        _audioSource.volume = value;
    }
}