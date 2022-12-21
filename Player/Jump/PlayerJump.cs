using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private CinemachineAnimator _cinemachineAnimator;
    [SerializeField] private PlayerGround _ground;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float gravityScale = 1;
    [SerializeField] private float jumpHeight = 4;
    
    private CharacterController _characterController;
    private float velocity;

    private void Awake() =>
        _characterController = GetComponent<CharacterController>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _ground.OnGround)
        {
            _cinemachineAnimator.Jump();
        }
        velocity += gravity * gravityScale * Time.deltaTime;
        Move();
    }

    private void Move()
    {
        _characterController.Move(new Vector3(0, velocity, 0) * Time.deltaTime);
    }

    public void Jump()
    {
        velocity = Mathf.Sqrt(jumpHeight * -2f * (gravity * gravityScale));
    }

    public void TryToJump()
    {
        if (_ground.OnGround)
        {
            _cinemachineAnimator.Jump();
        }
    }
}