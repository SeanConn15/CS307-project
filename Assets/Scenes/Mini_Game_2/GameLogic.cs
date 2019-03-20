//Author: Haoran Wang
//Purpose: Player will die if they fall off the map

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    bool isGrounded = true;

    public Text fallText;

    IEnumerator LoadAfterDelay(string levelName){
         yield return new WaitForSeconds(2.0f);
         Application.LoadLevel(levelName);

     }

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
      || Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, 1000.0f)
      || Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 1000.0f)
      || Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 1000.0f)
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
          fallText.text = "You are so Dead!!";
          StartCoroutine(LoadAfterDelay("game_2"));
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
          Application.LoadLevel("game_2");
        }

    }

}
