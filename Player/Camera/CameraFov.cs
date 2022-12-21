using Cinemachine;
using UnityEngine;

public class CameraFov : MonoBehaviour
{
    [SerializeField] private Camera _weaponcamera;
    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private float _moveFov;

    public float DefaultFov { get; private set; }

    private void Awake()
    {
        DefaultFov = _weaponcamera.fieldOfView;
    }

    private void OnEnable()
    {
        _movement.Move += SetMoveFov;
        _movement.NotMove += SetDefaultFov;
    }

    private void OnDisable()
    {
        _movement.Move -= SetMoveFov;
        _movement.NotMove -= SetDefaultFov;
    }

    public void SetMoveFov()
    {
        LerpFov(_moveFov);
    }

    public void SetDefaultFov()
    {
        LerpFov(DefaultFov);
    }

    private void LerpFov(float value)
    {
        _cinemachineVirtualCamera.m_Lens.FieldOfView =
            Mathf.Lerp(_cinemachineVirtualCamera.m_Lens.FieldOfView, value, 0.2f);
        _weaponcamera.fieldOfView =
            Mathf.Lerp(_weaponcamera.fieldOfView, value, 0.2f);
    }

    public void SetWithoutLerpFov(float value)
    {
        _cinemachineVirtualCamera.m_Lens.FieldOfView = value;
        _weaponcamera.fieldOfView = value;
    }
}