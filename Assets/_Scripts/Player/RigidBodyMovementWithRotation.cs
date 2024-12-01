using System;
using UnityEngine;

public class RigidBodyMovementWithRotation : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private float _rotationSpeed;
    
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _bodyTransform;
    
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    
    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotateInDirectionOfInput();
    }

    private void SetPlayerVelocity()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput,
            _movementInput,
            ref _movementInputSmoothVelocity,
            0.1f);

        _rigidbody.velocity = _smoothedMovementInput * _speed;
    }

    private void RotateInDirectionOfInput()
    {
        if (_movementInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(_bodyTransform.forward, _smoothedMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(_bodyTransform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            _rigidbody.MoveRotation(rotation);
        }
    }
    
    protected void OnMove(Vector2 inputValue)
    {
        _movementInput = inputValue;
    }
}