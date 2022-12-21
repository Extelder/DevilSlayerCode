using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UniRx;
using UnityEngine.EventSystems;

public class CameraRotation : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerUpHandler
{
    
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject[] _buttons;
    
    private CinemachinePOV _virtualCameraPov;
    private CompositeDisposable _disposable = new CompositeDisposable();
    private int TouchId = 0;
    private bool MobileDevice = true;

    public bool Pressed { get; private set; } = false;

    private void OnEnable()
    {
        Observable.EveryLateUpdate().Subscribe(_ =>
        {
            if (Pressed)
            {
                if (Input.GetTouch(TouchId).phase == TouchPhase.Stationary)
                {
                    _canvas.sortingOrder = 0;
                    SetInputAxisesValue(new Vector2(0, 0));
                }
            }
        }).AddTo(_disposable);
    }

    private void OnDisable() => _disposable.Clear();

    private void Awake()
    {
        _virtualCameraPov = _virtualCamera.GetCinemachineComponent<CinemachinePOV>();
        if (MobileDevice)
        {
            SetInputAxisesNames(null, null);
        }
        else
            SetInputAxisesNames("Mouse X", "Mouse Y");
    }

    public void OnDrag(PointerEventData eventData)
    {
        foreach (var button in _buttons)
        {
            if (eventData.pointerCurrentRaycast.gameObject == gameObject || eventData.pointerCurrentRaycast.gameObject == button.gameObject)
            {
                Drag(eventData);
                Pressed = true;
            }
            else
            {
                _canvas.sortingOrder = 0;
                SetInputAxisesValue(new Vector2(0, 0));
            }
        }
    }

    public void Drag(PointerEventData eventData)
    {
        _canvas.sortingOrder = 2;
        TouchId = eventData.pointerId;
        if (Input.GetTouch(eventData.pointerId).phase == TouchPhase.Moved)
        {
            SetInputAxisesValue(new Vector2(eventData.delta.x, eventData.delta.y));
        }
        else
        {
            SetInputAxisesValue(new Vector2(0, 0));
        }
    }

    public void EndDrag()
    {
        Pressed = false;
        SetInputAxisesValue(new Vector2(0, 0));
        _canvas.sortingOrder = 0;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        EndDrag();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        EndDrag();
    }


    private void SetInputAxisesValue(Vector2 value)
    {
        _virtualCameraPov.m_HorizontalAxis.m_InputAxisValue = value.x;
        _virtualCameraPov.m_VerticalAxis.m_InputAxisValue = value.y;
    }

    private void SetInputAxisesNames(string horizontal, string vertical)
    {
        _virtualCameraPov.m_HorizontalAxis.m_InputAxisName = horizontal;
        _virtualCameraPov.m_VerticalAxis.m_InputAxisName = vertical;
    }

    private void SetInputAxisMaxSpeed(Vector2 value)
    {
        _virtualCameraPov.m_HorizontalAxis.m_MaxSpeed = value.x;
        _virtualCameraPov.m_VerticalAxis.m_MaxSpeed = value.y;
    }
}