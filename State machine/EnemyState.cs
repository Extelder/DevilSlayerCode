using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState :  MonoBehaviour
{
    public bool CanChangeState { get; set; } = true;
    
    public abstract void Enter();
    
    public abstract void Exit();
}
