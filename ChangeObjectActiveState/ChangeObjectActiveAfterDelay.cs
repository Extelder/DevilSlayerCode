using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectActiveAfterDelay : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private GameObject _gameObject;

    private void Start()
    {
        Destroy(_gameObject, _delay);
    }
}