using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    bool isGrounded = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
      RaycastHit hit;

      if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1000.0f)
      || Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1000.0f)
      )
      {
          Debug.Log("floor");
          isGrounded = true;
      }
      else
      {
          isGrounded = false;
      }

        if (isGrounded == false)
        {
          SceneManager.LoadScene("game_2");
        }
    }

}
