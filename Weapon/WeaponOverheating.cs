using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class WeaponOverheating : MonoBehaviour
{
    [SerializeField] private WeaponAutoFire _autoFire;
    [SerializeField] private WeaponFire _fire;
    [SerializeField] private WeaponCooldown _cooldown;
    [SerializeField] private float _maxValue;
    [SerializeField] private float _decrreaseOverheatValue;

    private float _currentValue;

    private CompositeDisposable _disposable = new CompositeDisposable();

    public event Action<float> CurrentOverheatValueChange;

    private void OnEnable()
    {
        Recharge();
        _fire.Shooted += Overheat;
    }

    private void Start()
    {
        _currentValue = _maxValue;
    }

    private void OnDisable()
    {
        _fire.Shooted -= Overheat;
        _disposable.Clear();
    }

    public void Overheat()
    {
        if (_currentValue - _decrreaseOverheatValue <= 0)
        {
            _fire.CanFire = false;
            _currentValue = 0;
            if (_autoFire != null)
                _autoFire.enabled = false;
            _cooldown.Activate();
            CurrentOverheatValueChange?.Invoke(_currentValue);
            return;
        }

        _currentValue -= _decrreaseOverheatValue;
        CurrentOverheatValueChange?.Invoke(_currentValue);
    }

    public void Recharge()
    {
        if (_autoFire != null)
            _autoFire.enabled = true;
        _fire.CanFire = true;
        Observable.EveryUpdate().Subscribe(_ =>
        {
            if (_currentValue < _maxValue)
            {
                _currentValue += Time.deltaTime * 5;
            }

            CurrentOverheatValueChange?.Invoke(_currentValue);
        }).AddTo(_disposable);
    }

    public void SetMaxValue()
    {
        _currentValue = _maxValue;
        CurrentOverheatValueChange?.Invoke(_currentValue);
    }
}