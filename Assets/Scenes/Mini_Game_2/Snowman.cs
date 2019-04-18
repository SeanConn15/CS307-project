//Author: Haoran Wang
//Purpose: Player will die instantly if they run into snowman

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Snowman : MonoBehaviour
{
    
    public GameObject Player;
    public float Radius;

    public Text snowmanText;

    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator LoadAfterDelay(string levelName){
         yield return new WaitForSeconds(2.0f);
         Application.LoadLevel(levelName);
     }

    // Update is called once per frame
    void Update()
    {
      float dist = Vector3.Distance(Player.transform.position, transform.position);

      if (dist < Radius)
      {
          snowmanText.text = "Snowman! You are Dead!";
          StartCoroutine(LoadAfterDelay("game_2"));
            CoinTextScript.coinCount = 0;
      }
    }
}
