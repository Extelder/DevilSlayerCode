using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : EnemyState
{
    [SerializeField] private EnemyAnimator _animator;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _player;
    
    private CompositeDisposable _disposable = new CompositeDisposable();

    public override void Enter()
    {
        Observable.EveryLateUpdate().Subscribe(_ =>
        {
            _animator.Chase();
            _agent.SetDestination(_player.position);
        }).AddTo(_disposable);
    }

    public override void Exit()
    {
        _disposable.Clear();
    }

    private void OnDisable()
    {
        _disposable.Clear();
    }
}