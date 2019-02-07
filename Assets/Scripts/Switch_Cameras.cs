// Aurthor: Haoran Wang
// Purpose: let player switch between different levels by pressing left or right arrow keys

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Cameras : MonoBehaviour
{
    public Camera[] cameraList;
    private int currentCamera;

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
      }

    }
}
