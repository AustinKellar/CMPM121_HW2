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

    private Vector3 _previousFrameRotation;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _grounded = GetComponent<PlayerGrounded>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_input.RotationalMovement > 0.1f || _input.RotationalMovement < -0.1f)
        {
            transform.Rotate(new Vector3(0, _input.RotationalMovement, 0) * _rotationSpeed);
            _previousFrameRotation = transform.eulerAngles;
        }
        else
        {
            transform.eulerAngles = _previousFrameRotation;
        }

        Vector3 movement = transform.forward * _input.ForwardMovement;

        if (_input.IsSprinting)
        {
            _rigidbody.MovePosition(transform.position + movement * _sprintingSpeed);

        }
        else
        {
            _rigidbody.MovePosition(transform.position + movement * _walkingSpeed);
        }

        if (_input.Jump && _grounded.IsGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}
