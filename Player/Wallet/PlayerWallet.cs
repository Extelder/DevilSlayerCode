using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    private int _currentValue;
    private const int _minValue = 0;

    public event Action<int> CurrentCoinValueChanged;

    public void AddCoins(int value)
    {
        if (_currentValue + value <= _minValue)
        {
            _currentValue = _minValue;
            CurrentCoinValueChanged?.Invoke(_currentValue);
            return;
        }

        _currentValue += value;
        CurrentCoinValueChanged?.Invoke(_currentValue);
    }

    public void SpendCoins(int value, Action OnSpendSuccesfull)
    {
        if (_currentValue - value < _minValue)
            return;
        _currentValue -= value;
        CurrentCoinValueChanged?.Invoke(_currentValue);
        OnSpendSuccesfull?.Invoke();
    }
}