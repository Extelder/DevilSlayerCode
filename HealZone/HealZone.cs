using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealZone : MonoBehaviour
{
    [SerializeField] private float _valueToHeal;
    [SerializeField] private float _healDelay;
    [SerializeField] private Health _currentHealthToHeal;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerHealth>(out PlayerHealth health))
        {
            _currentHealthToHeal = health;
            StartCoroutine(Healing());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerHealth>(out PlayerHealth health))
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator Healing()
    {
        while (true)
        {
            yield return new WaitForSeconds(_healDelay);
            _currentHealthToHeal.Heal(_valueToHeal);
        }
    }
}