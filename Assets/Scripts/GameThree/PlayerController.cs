﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ttm;

/*
Author: Xingyu Wang
Player Controller
*/

public class PlayerController : MonoBehaviour
{
    public PlayerStats stats;
    public GameObject att;
    public GameObject portal100;
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

    public int count = 0;
    public int count2 = 1;

    private bool isOnConveyor = false;
    private Collider conveyor; //used to keep track of the conveyor's direction

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
            if (Input.GetKeyDown(KeyCode.X)) {
                RaycastHit ack;
                if(Physics.Raycast(att.transform.position, att.transform.forward, out ack, 10)){
                    if(ack.transform.tag == "Enemy"){
                        count2--;
                        Debug.Log("asdasd" + count2);
                        ack.transform.gameObject.SetActive(false);
                        portal100.gameObject.SetActive(true);
                    }
                }
                this.animator.SetBool(key_isAttack01, true);      
            }
            else {
                this.animator.SetBool(key_isAttack01, false); 
            }
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
            if (isOnConveyor)
            {
                moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
                

                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection += conveyor.transform.forward / -1;
                moveDirection *= speed;
            }
            else { 
                moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
            }
            jump();
        }

        transform.Rotate(0, Input.GetAxis("Horizontal") * rotation_speed, 0);
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("damage"))
        {   
            stats.TakeDamage(1);
        }
        if (other.gameObject.CompareTag("portal"))
        {   
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (other.gameObject.CompareTag("MainPortal"))
        {   
            SceneManager.LoadScene(3);
        }
        if (other.gameObject.CompareTag("PickUp") && stats.Health != stats.MaxHealth)
        {  
            count++;
            other.gameObject.SetActive(false);
            stats.Heal(1);
        }
        if (other.gameObject.CompareTag("conveyor"))
        {
            isOnConveyor = true;
            conveyor = other;
        } 
        if (other.gameObject.CompareTag("PortalTo7"))
        {
            SceneManager.LoadScene(7);
        }
        if (other.gameObject.CompareTag("Teleport"))
        {
            SceneManager.LoadScene(9);
        }
        if (other.gameObject.CompareTag("room"))
        {
            SceneManager.LoadScene(10);
        }
        if (other.gameObject.CompareTag("room1"))
        {
            SceneManager.LoadScene(11);
        }
        if (other.gameObject.CompareTag("room3"))
        {
            SceneManager.LoadScene(12);
        }
        if (other.gameObject.CompareTag("portalto100"))
        {
            TeleportToMain.portal2 = true;
            SceneManager.LoadScene(9);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("conveyor"))
        {
            isOnConveyor = true;
            conveyor = other;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("conveyor"))
        {
            isOnConveyor = false;
        }

    }
    void OnCollisionEnter(Collision collision){
        
        if (collision.gameObject.CompareTag("MainPortal"))
        {   
            SceneManager.LoadScene(3);
        }
    }
}
