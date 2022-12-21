using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWalletUI : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private Text _text;

    private void OnEnable()
    {
        _wallet.CurrentCoinValueChanged += OnCurrentCoinsValueChanged;
    }

    private void OnDisable()
    {
        _wallet.CurrentCoinValueChanged -= OnCurrentCoinsValueChanged;
    }

    private void OnCurrentCoinsValueChanged(int value)
    {
        _text.text = value.ToString();
    }
}