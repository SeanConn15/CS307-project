//Author: Haoran Wang
//Purpose: Player will rotate 180 degree if they run into reverse prop

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reverse : MonoBehaviour
{

    public GameObject Player;
    public float Radius;

    public Text reverseText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      float dist = Vector3.Distance(Player.transform.position, transform.position);

      if (dist < Radius)
      {
          Debug.Log("in");
          Player.transform.Rotate(0,-180,0,Space.World);
          Radius = 0;
          reverseText.text = "Wrong Way! mofo";
          Destroy(reverseText, 3.0f);
      }
    }
}
