using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class LookAtPlayerGameObject : MonoBehaviour
{
    private Transform _player;
    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Start()
    {
        _player = Player.Instance.transform;
    }

    private void OnEnable()
    {
        Observable.EveryLateUpdate().Subscribe(_ =>
        {
            if (_player != null) transform.LookAt(_player.position);
        }).AddTo(_disposable);
    }

    private void OnDisable()
    {
        _disposable.Clear();
    }
}