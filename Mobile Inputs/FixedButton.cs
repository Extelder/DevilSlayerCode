using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class FixedButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler,
    IPointerExitHandler
{
    [SerializeField] private FixedTouchField _touchField;

    public bool Pressed { get; set; }

    public UnityEvent OnButtonPressed;
    public UnityEvent OnButtonReleased;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnButtonPressed?.Invoke();
        _touchField.SetAllPointerData(eventData);
        Pressed = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Pressed || _touchField.Pressed)
            OnButtonPressed?.Invoke();
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        if (Pressed)
        {
            Pressed = false;
            _touchField.Pressed = false;
            OnButtonReleased?.Invoke();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Pressed == false)
        {
            OnButtonReleased?.Invoke();
        }
    }
}