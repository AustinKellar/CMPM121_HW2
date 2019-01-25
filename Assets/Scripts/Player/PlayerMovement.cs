using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerGrounded))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _walkingSpeed;

    [SerializeField]
    private float _sprintingSpeed;

    [SerializeField]
    private float _rotationSpeed;

    [SerializeField]
    private float _jumpForce;

    private PlayerInput _input;
    private PlayerGrounded _grounded;
    private Rigidbody _rigidbody;

    private RigidbodyConstraints _defaultConstraints;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _grounded = GetComponent<PlayerGrounded>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _defaultConstraints = _rigidbody.constraints;
    }

    private void FixedUpdate()
    {
        if (_input.RotationalMovement > 0.1f || _input.RotationalMovement < -0.1f)
        {
            _rigidbody.constraints = _defaultConstraints;
            transform.Rotate(new Vector3(0, _input.RotationalMovement, 0) * _rotationSpeed);
        }
        else
        {
            _rigidbody.freezeRotation = true;
        }

        Vector3 movement;
        if (_input.IsSprinting)
        {
            movement = transform.forward * _input.ForwardMovement * _sprintingSpeed;
        }
        else
        {
            movement = transform.forward * _input.ForwardMovement * _walkingSpeed;
        }

        if (_input.Jump && _grounded.IsGrounded)
        {
            movement.y += _jumpForce;
        }

        _rigidbody.velocity += movement;
    }
}
