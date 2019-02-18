using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// author: Xingyu Wang
// Protagnist movement controller
// left arror key: move left
// right arror key: move right
// space: jump
// need implementation

public class MovementController : MonoBehaviour
{

    public int moveSpeed = 5;
    public float m_jumpForce = 4f;
    public float rotationSpeed = 5f;

    public Rigidbody m_rigidBody;
    private Animator m_animator;

    private static Vector3 RightDirection = new Vector3(0, 0, 1);
    private static Vector3 LeftDirection = new Vector3(0, 0, -1);

    private float m_jumpTimeStamp = 0;
    private float m_minJumpInterval = 0.25f;

    private Vector3 FacingDirection = RightDirection;


    private void Start()
    {
        m_animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }



    // Update is called once per frame
    // TODO add animations
    void Update()
    {
        // jump
        if (Input.GetKeyDown(KeyCode.Space))
            jump();

        // run
        run();

        //if (Input.GetKey(KeyCode.R))
            //rotate();



    }


    // add a force for a timeStamp when space is pressed
    // should detect cooldown and isGrounded first
    // TODO isGrounded detection
    private void jump() {
        bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;

        if (jumpCooldownOver && Input.GetKey(KeyCode.Space))
        {
            m_jumpTimeStamp = Time.time;
            m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
            m_animator.SetFloat("MoveSpeed", 2);
            m_animator.SetTrigger("Jump");
        }
    }



    // player run
    // calculate movement length
    // calculate movement direction base on input
    // right arrow is positive, left arrow is negtive
    // change animator state base on movement length
    // TODO: rotation
    private void run() {
        float movementLength = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        Vector3 direction = movementLength > 0 ? RightDirection : LeftDirection;



        if (movementLength != 0)
        {
            //      if (FacingDirection != direction) {
            //         transform.Rotate(0, 180, 0);
            //         FacingDirection = direction;
            //     }

            m_animator.SetBool("isRunning", true);
            //if (direction == LeftDirection) direction *= -1;
            transform.Translate(rotate(direction) * moveSpeed * Time.deltaTime, Space.Self);
        }
        else
        {
            m_animator.SetBool("isRunning", false);
        }
    }


    private Vector3 rotate(Vector3 newDirection) {
        if (FacingDirection != newDirection)
        {
            transform.Rotate(0, 180, 0);
            FacingDirection = newDirection;

        }
        if (newDirection == LeftDirection)
            newDirection *= -1;
        return newDirection;
    }

}
