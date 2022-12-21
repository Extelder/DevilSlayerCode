using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCombo : MonoBehaviour
{
    [SerializeField] private int _maxTimeToDisactivateCombo;
    private float _timeToDisactivateCombo;
    private int _currentComboMulitply = 0;

    public event Action<int> CurrentComboMultiplyChanged;
    public event Action<float> CurrentTimeToDisactivateComboChanged;

    private void OnEnable()
    {
        WeaponFire.OnHitEnemy += OnHitSomeHitBox;
    }

    private void OnDisable()
    {
        WeaponFire.OnHitEnemy -= OnHitSomeHitBox;
    }

    private void Update()
    {
        if (_timeToDisactivateCombo > 0)
        {
            _timeToDisactivateCombo -= Time.deltaTime;
            CurrentTimeToDisactivateComboChanged?.Invoke(_timeToDisactivateCombo);
            return;
        }

        _timeToDisactivateCombo = 0;
        _currentComboMulitply = 0;
        CurrentComboMultiplyChanged?.Invoke(_currentComboMulitply);
        CurrentTimeToDisactivateComboChanged?.Invoke(_timeToDisactivateCombo);
    }

    public void OnHitSomeHitBox(HitBox hitBox)
    {
        _timeToDisactivateCombo = _maxTimeToDisactivateCombo;
        CurrentTimeToDisactivateComboChanged?.Invoke(_timeToDisactivateCombo);
        if (hitBox is EnemyHeadHitBox enemyHeadHitBox)
        {
            OnHitHeadHitBox(enemyHeadHitBox);
            return;
        }

        OnHitHitBox(hitBox);
    }

    public void OnHitHeadHitBox(EnemyHeadHitBox headHitBox)
    {
        AddComboValues(2);
    }

    public void OnHitHitBox(HitBox hitBox)
    {
        AddComboValues(1);
    }

    private void AddComboValues(int combo)
    {
        _currentComboMulitply += combo;
        CurrentComboMultiplyChanged?.Invoke(_currentComboMulitply);
    }
}