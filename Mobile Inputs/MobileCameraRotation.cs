using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UniRx;
using UnityEngine;

public class MobileCameraRotation : MonoBehaviour
{
    [SerializeField] private FixedTouchField _touchField;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    
    private CinemachinePOV _cinemachinePov;
    private CompositeDisposable _disposable = new CompositeDisposable();

    [field: SerializeField] public Vector2 Sensetivity { get; set; }
    public Vector2 DefaultSensetivity { get; private set; }
    
    private void Awake() => _cinemachinePov = _virtualCamera.GetCinemachineComponent<CinemachinePOV>();

    private void Start()
    {
        DefaultSensetivity = Sensetivity;
    }

    private void OnEnable() => Observable.EveryLateUpdate().Subscribe(_ =>
    {
        _cinemachinePov.m_HorizontalAxis.m_InputAxisValue = _touchField.TouchDist.x * Sensetivity.x;
        _cinemachinePov.m_VerticalAxis.m_InputAxisValue = _touchField.TouchDist.y * Sensetivity.y;
    }).AddTo(_disposable);

    private void OnDisable() => _disposable.Clear();
}