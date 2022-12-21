using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerGameState : MonoBehaviour
{
    [SerializeField] private PlayerCursorLock _cursorLock;
    [SerializeField] private GameObject _winCanvas;
    [SerializeField] private GameObject _loseCanvas;

    public UnityEvent OnWin;
    public UnityEvent OnLose;
    
    private void Awake()
    {
        Time.timeScale = 1;
    }

    public void Win()
    {
        OnWin?.Invoke();
        SetCanvasActivate(_winCanvas);
    }

    public void Lose()
    {
        OnLose?.Invoke();
        SetCanvasActivate(_loseCanvas);
    }

    public void SetCanvasActivate(GameObject canvas)
    {
        _cursorLock.enabled = false;
        canvas.SetActive(true);
    }
}