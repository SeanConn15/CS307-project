//Aurthor: Haoran Wang
//Purpose: walk into bookstore

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
  	void OnTriggerEnter(Collider player) {

          if (player.gameObject.tag == "TP")
          {
              Debug.Log("in");
              SceneManager.LoadScene("UI_Custom");
          }
  	}
}
