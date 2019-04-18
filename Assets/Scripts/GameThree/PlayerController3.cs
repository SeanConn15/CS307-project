using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ttm;

/*
Author: Jisoo Cha
Player Controller
*/

public class PlayerController3 : MonoBehaviour
{
    public GameObject att;
    public GameObject balls;
    public GameObject portalto7;
    public PlayerStats stats;
    float speed = 8f;
    float rotation_speed = 3f;
    float gravity = 27f;
    float rotation = 0f;
    float jump_speed = 15f;

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
                if(Physics.Raycast(att.transform.position, att.transform.forward, out ack, 2)){
                    if(ack.transform.tag == "Enemy"){
                        ack.transform.gameObject.SetActive(false);
                        portalto7.gameObject.SetActive(true);
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
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
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
                moveDirection += (conveyor.transform.forward) * -0.8f;
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
        if (other.gameObject.CompareTag("Teleport"))
        {   
            SceneManager.LoadScene(9);
        }
        if (other.gameObject.CompareTag("Check2"))
        {   
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (other.gameObject.CompareTag("PickUp") && stats.Health != stats.MaxHealth)
        {  
            count++;
            other.gameObject.SetActive(false);
            stats.Heal(1);
        }
        if (other.gameObject.CompareTag("cannonball"))//if you got hit by a cannonball
        {
            if (other.GetComponent<Rigidbody>().velocity.magnitude > 4) //if the cannonball is still moving
            {
                Debug.Log("ouch!");
                Application.LoadLevel(Application.loadedLevel); //reload the level
            }
        }
        if (other.gameObject.CompareTag("enter3"))
        {   
            balls.gameObject.SetActive(true);
        }
        if (other.gameObject.CompareTag("portalto101"))
        {
            TeleportToMain.portal3 = true;
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
        if (collision.gameObject.CompareTag("Teleport"))
        {   
            TeleportToMain.portal1 = true;
            SceneManager.LoadScene(9);
        }
        if (collision.gameObject.CompareTag("blade"))
        {   
            stats.TakeDamage(1);
        }
    }
}