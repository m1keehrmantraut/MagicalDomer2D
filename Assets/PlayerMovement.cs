using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController2D _controller;

    [SerializeField] private float _runSpeed;

    [SerializeField] private Animator _animator;

    private float horizontalMove = 0f;
    private bool jump = false;
    private bool crouch = false;
    
    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * _runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } 
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    private void FixedUpdate()
    {
        _controller.Move(horizontalMove * Time.deltaTime, crouch, jump);
        _animator.SetFloat("Speed", Math.Abs(horizontalMove));
        _animator.SetBool("IsGrounded", !jump);
        jump = false;
    }


}
