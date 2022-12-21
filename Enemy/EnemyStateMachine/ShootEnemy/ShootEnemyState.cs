using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemyState : EnemyAttackState
{
    [SerializeField] private float _cooldown;
    [SerializeField] private ShootEnemySpellsSpawner _spellsSpawner;
    [SerializeField] private EnemyStateController _stateController;

    private void OnEnable()
    {
        StartCoroutine(AutoAttack());
    }

    private void Start()
    {
        _stateController.Attack();
    }

    private void OnDisable()
    {
        StopCoroutine(AutoAttack());
    }

    public override void Attack()
    {
        CanChangeState = false;
        _spellsSpawner.SpawnRandomSpell();
    }

    public override void AttackAnimationEnd()
    {
        base.AttackAnimationEnd();
        _stateController.Chase();
    }

    private IEnumerator AutoAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(_cooldown);
            _stateController.Attack();
        }
    }
}