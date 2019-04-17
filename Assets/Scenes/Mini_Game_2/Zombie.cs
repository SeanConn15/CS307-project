using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
  public GameObject Player;
  public float Radius;

  public Text ZombieText;

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
        ZombieText.text = "Zombie! You are Dead!";
        StartCoroutine(LoadAfterDelay("Final"));
    }
  }
}
