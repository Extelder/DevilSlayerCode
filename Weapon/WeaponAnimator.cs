using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimator : MonoBehaviour
{
    [SerializeField] private WeaponFire _weaponFire;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private Animator _animator;

    [SerializeField] private bool _mobile;
    public bool Stopped;
    
    private void OnEnable()
    {
        _movement.Move += WalkAnimation;
        _movement.NotMove += IdleAnimation;
    }

    private void OnDisable()
    {
        _movement.Move -= WalkAnimation;
        _movement.NotMove -= IdleAnimation;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && _mobile == false && Stopped == false)
        {
            FireAnimation();
        }
    }
    
    public void IdleAnimation()
    {
        DisableAllAnimationBool();
    }

    public void WalkAnimation()
    {
        SetAnimationBool("IsWalking");
    }

    public void FireAnimation()
    {
        if (_weaponFire.CanFire)
            SetAnimationBool("IsShooting");
    }

    public void ReloadAnimation()
    {
        SetAnimationBool("IsReloading");
    }

    private void SetAnimationBool(string name)
    {
        DisableAllAnimationBool();
        _animator.SetBool(name, true);
    }

    private void DisableAllAnimationBool()
    {
        _animator.SetBool("IsReloading", false);
        _animator.SetBool("IsShooting", false);
        _animator.SetBool("IsWalking", false);
    }
}