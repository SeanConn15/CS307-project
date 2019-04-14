//Author: Haoran Wang
//Purpose: end game and play a video

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShuttle : MonoBehaviour
{
  public GameObject Player;
  public float Radius;
  public GameObject videoPlayer;
  public GameObject audio;

  IEnumerator LoadAfterDelay(string levelName){
       yield return new WaitForSeconds(14.0f);
       Application.LoadLevel(levelName);
   }

  // Start is called before the first frame update
  void Start()
  {
    videoPlayer.SetActive(false);
  }

  // Update is called once per frame
  void Update()
  {
    float dist = Vector3.Distance(Player.transform.position, transform.position);

    if (dist < Radius)
    {
        Debug.Log("In");
        audio.SetActive(false);
        videoPlayer.SetActive(true);
        StartCoroutine(LoadAfterDelay("Forest"));
    }
  }
}
