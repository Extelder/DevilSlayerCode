using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [field: SerializeField] public float MaxValue { get; private set; }

    private float _currentValue;

    private const float _minValue = 0;

    public UnityEvent OnDeath;
    public event Action<float> OnCurrentHealthValueChaneged;

    private bool _dead;

    private void Awake()
    {
        _currentValue = MaxValue;
    }

    public virtual void TakeDamage(float damage)
    {
        if(_dead)
            return;
        if (_currentValue - damage <= _minValue)
        {
            _currentValue = 0;
            OnCurrentHealthValueChaneged?.Invoke(_currentValue);
            Death();
            return;
        }

        _currentValue -= damage;
        OnCurrentHealthValueChaneged?.Invoke(_currentValue);
    }

    public virtual void Death()
    {
        if (!_dead)
        {
            OnDeath?.Invoke();
            _dead = true;
        }
    }

    public void HealToMax()
    {
        _dead = false;
        _currentValue = MaxValue;
        OnCurrentHealthValueChaneged?.Invoke(_currentValue);
    }

    public void Heal(float value)
    {
        Debug.Log("Heal to " + _currentValue);
        if (_currentValue + value > MaxValue)
        {
            _currentValue = MaxValue;
            OnCurrentHealthValueChaneged?.Invoke(_currentValue);
            return;
        }

        _currentValue += value;
        OnCurrentHealthValueChaneged?.Invoke(_currentValue);
    }
}