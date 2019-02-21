//Author: Haoran Wang
//Purpose: To play intro video. Let the user to press space bar to skip if they wish.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayVideo : MonoBehaviour {

    public GameObject videoPlayer;
    public GameObject currentCamera;
    //public GameObject nextCamera;

	// Use this for initialization
	void Start () {
        videoPlayer.SetActive(true);
        //nextCamera.SetActive(false);
	}

	// Update is called once per frame
	void Update() {
      if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.RightArrow)){
        Destroy(videoPlayer);
        currentCamera.SetActive(false);
          SceneManager.LoadScene("Customization");
      }
  }
}
