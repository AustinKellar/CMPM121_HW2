using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerGrounded))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    private PlayerInput _input;
    private PlayerGrounded _grounded;
    private Animator _animator;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _grounded = GetComponent<PlayerGrounded>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {

        if (_grounded.IsGrounded)
        {
            _animator.SetFloat("Walk", _input.ForwardMovement);
        }
        else if (!_input.IsSprinting)
        {
            _animator.SetFloat("Walk", 0f);
        }

        if (_input.IsSprinting)
        {
            _animator.SetFloat("Run", 0.2f);
        }
        else
        {
            _animator.SetFloat("Run", 0f);
        }

        _animator.SetFloat("Turn", _input.RotationalMovement);

        _animator.SetBool("Jump", _input.Jump && _grounded.IsGrounded);
    }
}