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

    public int moveSpeed = 3;
    public float m_jumpForce = 4f;
    public float rotationSpeed = 5f;

    public Rigidbody m_rigidBody;
    private Animator m_animator;

    private static Vector3 RightDirection = new Vector3(0, 0, 1);
    private static Vector3 LeftDirection = new Vector3(0, 0, -1);


    private Vector3 FacingDirection = RightDirection;
    private float distanceToGround = 0.4f;

    public Collider collider;


    private void Start()
    {
        m_animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
        distanceToGround = collider.bounds.extents.y;
        collider = new Collider();
    }



    // Update is called once per frame
    void Update()
    {
        jump();

        run();

        // Test mouse
        if (Input.GetMouseButtonDown(0))
        {
          Debug.Log("Mouse Okay");
        }
    }


    // add a force for a timeStamp when space is pressed
    // should detect cooldown and isGrounded first
    private void jump() {
        m_animator.SetBool("Grounded", isGrounded());

        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            m_animator.SetTrigger("Jump");
            m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
        }
    }

    private bool isGrounded() {
        return Physics.Raycast(transform.position, Vector3.down, distanceToGround + 0.4f);
    }





    // player run
    // calculate movement length
    // calculate movement direction base on input
    // right arrow is positive, left arrow is negtive
    // change animator state base on movement length
    private void run() {
        float movementLength = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        Vector3 direction = movementLength > 0 ? RightDirection : LeftDirection;

        if (movementLength != 0)
        {
            if (isGrounded()) m_animator.SetBool("isRunning", true);
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
