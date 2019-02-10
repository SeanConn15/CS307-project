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
    public float m_jumpForce = 4;
    public Rigidbody m_rigidBody;

    private static Vector3 RightDirection = new Vector3(0, 0, 1);
    private static Vector3 LeftDirection = new Vector3(0, 0, -1);

    private float m_jumpTimeStamp = 0;
    private float m_minJumpInterval = 0.25f;



    // Update is called once per frame
    // TODO add animations
    void Update()
    {
        // jump
        if (Input.GetKey(KeyCode.Space))
            jump();

        // move right
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(RightDirection * moveSpeed * Time.deltaTime);

        // move left 
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(LeftDirection * moveSpeed * Time.deltaTime);
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
        }
    }
}
