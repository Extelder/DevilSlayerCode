using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMonumentsCheckDestroyed : MonoBehaviour
{
    [SerializeField] private int _allMonuments;

    private int _destroyedMonuments;

    public UnityEvent OnAllMonumentsDestroyed;
    
    public void MonumentDestroyed()
    {
        _destroyedMonuments += 1;
        if (_allMonuments == _destroyedMonuments)
        {
            OnAllMonumentsDestroyed?.Invoke();
        }
    }
    
}
