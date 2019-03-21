using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{

    public GameObject Player;
    public float Radius;

    public Text finishText;

    IEnumerator LoadAfterDelay(string levelName){
         yield return new WaitForSeconds(2.0f);
         Application.LoadLevel(levelName);
     }

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
          finishText.text = "Good Job! You made it!";
          StartCoroutine(LoadAfterDelay("Main Scene"));
      }
    }
}
