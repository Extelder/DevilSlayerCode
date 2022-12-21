using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hip : MonoBehaviour
{
    [SerializeField] private float _timeToDisactivateHipAfterEnemyHit;
    [SerializeField] private GameObject _hitHip;
    [SerializeField] private GameObject _headHitHip;

    private void OnEnable()
    {
        WeaponFire.OnHitEnemy += OnHittedEnemy;
    }

    private void OnDisable()
    {
        WeaponFire.OnHitEnemy -= OnHittedEnemy;
    }

    private void OnHittedEnemy(HitBox hittedObject)
    {
        _hitHip.SetActive(false);
        _headHitHip.SetActive(false);
        StopAllCoroutines();
        StartCoroutine(AutoHipDisable());
        if (hittedObject is EnemyHeadHitBox)
        {
            _headHitHip.SetActive(true);
            return;
        }
        _hitHip.SetActive(true);
    }

    private IEnumerator AutoHipDisable()
    {
        yield return new WaitForSeconds(_timeToDisactivateHipAfterEnemyHit);
        _hitHip.SetActive(false);
        _headHitHip.SetActive(false);
    }
}
