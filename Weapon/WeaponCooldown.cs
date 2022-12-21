using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class WeaponCooldown : MonoBehaviour
{
    [SerializeField] private WeaponCooldownUI _ui;
    [SerializeField] private WeaponOverheating _overheating;
    [field: SerializeField] public float TimeMultiplayer { get; private set; }

    private CompositeDisposable _disposable = new CompositeDisposable();
    private float _value = 100;

    private void OnDisable()
    {
        _disposable.Clear();
    }

    public void Activate()
    {
        _overheating.enabled = false;
        _ui.CooldownBegined();
        Observable.EveryUpdate().Subscribe(_ =>
        {
            if (_value <= 0)
            {
                CooldownEnd();
                _disposable.Clear();
            }

            _value -= Time.deltaTime * TimeMultiplayer;
            _ui.CooldownUpdated(_value);
        }).AddTo(_disposable);
    }

    public void CooldownEnd()
    {
        _overheating.enabled = true;
        _overheating.SetMaxValue();
        _value = 100;
        _disposable.Clear();
    }

    public void AddToTimeMultiplyValue(float value)
    {
        if (TimeMultiplayer + value <= 0)
        {
            TimeMultiplayer = 0;
            return;
        }

        TimeMultiplayer += value;
    }
}