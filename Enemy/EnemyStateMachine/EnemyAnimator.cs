using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Chase()
    {
        SetAnimationBool("IsChasing");
    }

    public void Attack()
    {
        SetAnimationBool("IsAttacking");
    }

    public void TakeDamage()
    {
        SetAnimationBool("IsTakingDamage");
    }
    
    public void Death()
    {
       SetAnimationBool("IsDeath");
    }
    
    private void SetAnimationBool(string name)
    {
        DisableAllBools();
        _animator.SetBool(name, true);
    }
    
    public void DisableAllBools()
    {
        _animator.SetBool("IsChasing", false);
        _animator.SetBool("IsTakingDamage", false);
        _animator.SetBool("IsAttacking", false);
    }
}
