using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class EnemyAttackZone : MonoBehaviour
{
    [SerializeField] private Health _healthToDetect;
    public ReactiveProperty<bool> Detected { get; private set; } = new ReactiveProperty<bool>();

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Health>(out Health health))
        {
            if (health == _healthToDetect)
                Detected.Value = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Health>(out Health health))
        {
            if (health == _healthToDetect)
                Detected.Value = false;
        }
    }
}