using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private GameObject _enemyParent;

    public void DeathAnimationBegin()
    {
        _agent.speed = 0;
    }
    
    public void Death()
    {
        Destroy(_enemyParent);
    }
}
