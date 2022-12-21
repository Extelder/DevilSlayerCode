using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class EnemyStateController : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private EnemyAttackZone _attackZone;
    [SerializeField] private EnemyState _runState;
    [SerializeField] private EnemyState _attackState;
    [SerializeField] private EnemyState _takeDamageState;
 
    private EnemyStateMachine _machine;
    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Awake()
    {
        _machine = new EnemyStateMachine(_runState);
    }

    private void OnEnable()
    {
        _health.OnCurrentHealthValueChaneged += OnHealthValueChanged;
        EnablePlayerDetect();
    }


    private void OnDisable()
    {
        _health.OnCurrentHealthValueChaneged -= OnHealthValueChanged;
        DisablePlayerDetect();
    }

    private void OnHealthValueChanged(float value)
    {
        if(value > 0)
            TakeDamage();
    }

    public void Chase()
    {
        _machine.ChangeState(_runState);
    }

    public void Attack()
    {
        _machine.CurrentState.CanChangeState = true;
        _machine.ChangeState(_attackState);
    }

    public void TakeDamage()
    {
        _machine.ChangeState(_takeDamageState);
    }

    public virtual void EnablePlayerDetect()
    {
        _attackZone.Detected.Subscribe(detected =>
        {
            if (detected)
            {
                Attack();
                return;
            }

            Chase();
        }).AddTo(_disposable);
    }

    public virtual void DisablePlayerDetect()
    {
        _disposable.Clear();
    }
}