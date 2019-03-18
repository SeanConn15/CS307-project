// Aurthor: Haoran Wang
// Purpose: let player switch between different levels by pressing left or right arrow keys

//Jisoo Cha: added statement that when press up arrow key on camera one,
//camera moves autometically to the portal and change to scene one.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch_Cameras : MonoBehaviour
{
    public Camera[] cameraList;
    private int currentCamera;

    //added by jisoo
    public AutoMove automove1;
    public AutoMove automove2;
    public AutoMove automove3;

    // Start is called before the first frame update
    void Start()
    {
        // Always start at scene 1
        currentCamera = 0;
        for (int i = 0; i < cameraList.Length; i++)
        {
          cameraList[i].gameObject.SetActive(false);
        }

        if (cameraList.Length > 0)
        {
          cameraList[0].gameObject.SetActive (true);
        }
    }

    // Update is called once per frame
    void Update()
    {
    if (currentCamera >= 0){
        // Right Arrow Key
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
          currentCamera++;
          if (currentCamera < cameraList.Length)
          {
            cameraList[currentCamera - 1].gameObject.SetActive(false);
            cameraList[currentCamera].gameObject.SetActive(true);
          }
          else
          {
            cameraList[currentCamera - 1].gameObject.SetActive(false);
            currentCamera = 0;
            cameraList[currentCamera].gameObject.SetActive(true);
          }
        }

        // Left Arrow Key
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentCamera >= 1)
        {
          currentCamera--;
          if (currentCamera >= 0 && currentCamera < cameraList.Length)
          {
            cameraList[currentCamera + 1].gameObject.SetActive(false);
            cameraList[currentCamera].gameObject.SetActive(true);
          }
          else {
            cameraList[currentCamera + 1].gameObject.SetActive(false);
            currentCamera = 0;
            cameraList[currentCamera].gameObject.SetActive(true);
          }
        }
            //added by jisoo camera for scene one move if press uparrow key
            if (currentCamera == 1)
            {
                automove1.changeScene |= Input.GetKeyDown(KeyCode.UpArrow);
            }
            //if (currentCamera == 2)
            //{
                //automove2.changeScene |= Input.GetKeyDown(KeyCode.UpArrow);
            //}
            if (currentCamera == 3)
            {
                automove3.changeScene |= Input.GetKeyDown(KeyCode.UpArrow);
            }

            //for mini game 2
            if (currentCamera == 2)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                  SceneManager.LoadScene("game_2");
                }
            }
        }
    }
}
