using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    private PlayerInput _input;
    private Rigidbody _rigidbody;

    private Vector3 _previousFrameRotation;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_input.SideMovement > 0.1f || _input.SideMovement < -0.1f)
        {
            transform.Rotate(new Vector3(0, _input.SideMovement, 0) * _rotationSpeed);
            _previousFrameRotation = transform.eulerAngles;
        }
        else
        {
            transform.eulerAngles = _previousFrameRotation;
        }

        Vector3 movement = transform.forward * _input.ForwardMovement;
        _rigidbody.MovePosition(transform.position + movement * _speed);
    }
}
