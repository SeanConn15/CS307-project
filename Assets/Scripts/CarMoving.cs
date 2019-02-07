//Author: Haoran Wang
//Purpose: move prop cars in a direction

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoving : MonoBehaviour
{
    public static int moveSpeed = 1;
    public Vector3 Direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(Direction * moveSpeed * Time.deltaTime);
    }
}
