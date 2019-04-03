//Creator: Sean Connelly
//Purpose: controlls a camera on a dolley like setup, tracks the players foreward/backward position but ignores up and down/left and right
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public float offsetX;
    public float offsetY;
    public float zPos;

    private void Start()
    {
        Vector3 desiredPosition = new Vector3(target.position.x + offsetX, offsetY, zPos);

        transform.position = desiredPosition;
    }
    void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x + offsetX, offsetY, zPos);


        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        //transform.LookAt(target);
    }
}
