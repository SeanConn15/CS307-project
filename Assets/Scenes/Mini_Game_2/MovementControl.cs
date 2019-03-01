using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour
{

    public float speed;
    CharacterController charControl;

    // Start is called before the first frame update
    void Start()
    {
      charControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      float horiz = Input.GetAxis("Horizontal");
     float vert = Input.GetAxis("Vertical");

     Vector3 moveDirSide = transform.right * horiz * speed;
     Vector3 moveDirForward = transform.forward * vert * speed;

     charControl.SimpleMove(moveDirSide);
     charControl.SimpleMove(moveDirForward);
    }
}
