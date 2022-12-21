using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speed;
    [SerializeField] private bool _mobile;

    private CharacterController _characterController;

    public event Action Move;
    public event Action NotMove;

    private void Awake() =>
        _characterController = GetComponent<CharacterController>();

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3();
        Vector2 InputAxises = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (_mobile)
        {
            InputAxises = new Vector2(_joystick.Horizontal, _joystick.Vertical);
        }

        direction =
            new Vector3(InputAxises.x * _speed, 0, InputAxises.y * _speed);

        direction = transform.TransformDirection(direction);
        _characterController.Move(direction * Time.deltaTime);
        if (MathF.Abs(direction.x) > 0 || MathF.Abs(direction.y) > 0)
        {
            Move?.Invoke();
        }
        else
        {
            NotMove?.Invoke();
        }
    }
}