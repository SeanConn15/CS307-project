using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Author: Xingyu Wang
Player Controller
*/

public class PlayerController : MonoBehaviour
{
    float speed = 8f;
    float rotation_speed = 3f;
    float gravity = 27f;
    float rotation = 0f;
    float jump_speed = 10f;

    private const string key_isRun = "IsRun";
    private const string key_isAttack01 = "IsAttack01";
    private const string key_isAttack02 = "IsAttack02";
    private const string key_isJump = "IsJump";
    private const string key_isDamage = "IsDamage";
    private const string key_isDead = "IsDead";

    Vector3 moveDirection = Vector3.zero;
    CharacterController controller;     // Character Controller Object, provided by Unity
    Animator animator;
    int jumps;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        attack();
        movement();

    }

    private void jump()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                this.animator.SetBool(key_isJump, true);
                moveDirection.y = jump_speed;
            }
            else
            {
                this.animator.SetBool(key_isJump, false);
            }
        }
    }

  

    private void attack() 
    { 
        if (controller.isGrounded) 
        {
            if (Input.GetKeyDown(KeyCode.X)) 
                this.animator.SetBool(key_isAttack01, true);
            else 
                this.animator.SetBool(key_isAttack01, false);
        }
    }


    // move when pressing UpArrow
    private void move()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.UpArrow))
                this.animator.SetBool(key_isRun, true);
            else 
                this.animator.SetBool(key_isRun, false);
        }
    }


    private void movement() 
    { 
        if (controller.isGrounded) 
        {
            move();

            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            jump();
        }

        transform.Rotate(0, Input.GetAxis("Horizontal") * rotation_speed, 0);
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }


}
