using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerJump _playerJump;

    private bool _jumping;

    public void Jump()
    {
        if (_jumping == false)
        {
            _jumping = true;
            _animator.SetBool("IsJumping", true);
        }
    }

    private void EndJump()
    {
        _playerJump.Jump();
        _jumping = false;
        _animator.SetBool("IsJumping", false);
    }
}