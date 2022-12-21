using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRevive : MonoBehaviour
{
    [SerializeField] private GameObject _reviveCanvas;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private float _timeToRevive;
    private Vector3 _lastPlayerPosition;

    private bool _waiting;

    public void OnDead()
    {
       StartCoroutine(Revive());
    }

    private IEnumerator Revive()
    {
        _reviveCanvas.SetActive(true);
        yield return new WaitForSeconds(_timeToRevive);
        _reviveCanvas.SetActive(false);
        _playerHealth.HealToMax();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}