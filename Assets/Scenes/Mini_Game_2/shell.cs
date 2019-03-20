//Author: Haoran Wang
//Purpose: Player will get vision blocked if they run into shell

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell : MonoBehaviour
{

    public GameObject Player;
    public float Radius;

    public GameObject shellCam;

    private bool shellActive;

    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator AfterDelay(){
         yield return new WaitForSeconds(2.0f);
         shellCam.SetActive(false);
     }

    // Update is called once per frame
    void Update()
    {
      float dist = Vector3.Distance(Player.transform.position, transform.position);

      if (dist < Radius)
      {
          shellCam.SetActive(true);
          Radius = 0;
          shellActive = true;
      }

      if (shellActive == true)
      {
          StartCoroutine(AfterDelay());
      }

    }
}
