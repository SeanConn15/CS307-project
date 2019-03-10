using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Author: Xingyu Wang
Player Controller
*/

public class PlayerController : MonoBehaviour
{
    float speed = 4f;
    float rotation_speed = 80f;
    float gravity = 8f;
    float rotation = 0f;

    private const string key_isRun = "IsRun";
    private const string key_isAttack01 = "IsAttack01";
    private const string key_isAttack02 = "IsAttack02";
    private const string key_isJump = "IsJump";
    private const string key_isDamage = "IsDamage";
    private const string key_isDead = "IsDead";

    Vector3 moveDirection = Vector3.zero;
    CharacterController controller;     // Character Controller Object, provided by Unity
    Animator animator;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        move();
    }



    // move when pressing UpArrow
    private void move()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveDirection = new Vector3(0, 0, 1);
                this.animator.SetBool(key_isRun, true);
            } 
            else 
            { 
                moveDirection = new Vector3(0, 0, 0);
                this.animator.SetBool(key_isRun, false);
            }
        }

        setDirection();
        controller.Move(moveDirection * Time.deltaTime);
    }

    // set movement direction
    private void setDirection()
    {
        rotate();
        moveDirection *= speed;
        moveDirection = transform.TransformDirection(moveDirection);    // transform from local axis to Global axis
        moveDirection.y -= gravity * Time.deltaTime;
    }

    // accept horizontal input and transform it into a vector 
    private void rotate() 
    {
        // get horizontal input
        rotation += Input.GetAxis("Horizontal") * rotation_speed * Time.deltaTime;

        // transform input into vector
        transform.eulerAngles = new Vector3(0, rotation, 0);
    }






}
