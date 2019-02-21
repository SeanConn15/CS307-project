//Author: Haoran Wang
//Purpose: customize character's hair and clothing

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Character : MonoBehaviour
{
  public GameObject[] characterList;
  private int currentCharacter;
  private GameObject clone;

    // Start is called before the first frame update
    void Start()
    {
      currentCharacter = 0;

      if (characterList.Length > 0)
      {
        clone = Instantiate(characterList[0],new Vector3(-0.3f,0.02f,-5.4f),Quaternion.Euler(new Vector3(0, 180, 0)));
      }
    }

    // Update is called once per frame
    void Update()
    {
      if (currentCharacter >= 0){
          // Right Arrow Key
          if (Input.GetKeyDown(KeyCode.RightArrow))
          {
            currentCharacter++;
            if (currentCharacter < characterList.Length)
            {
              Destroy(clone);
              clone = Instantiate(characterList[currentCharacter],new Vector3(-0.3f,0.02f,-5.4f),Quaternion.Euler(new Vector3(0, 180, 0)));
            }
            else
            {
              Destroy(clone);
              currentCharacter = 0;
              clone = Instantiate(characterList[currentCharacter],new Vector3(-0.3f,0.02f,-5.4f),Quaternion.Euler(new Vector3(0, 180, 0)));
            }
          }

          // Left Arrow Key
          if (Input.GetKeyDown(KeyCode.LeftArrow) && currentCharacter >= 1)
          {
            currentCharacter--;
            if (currentCharacter >= 0 && currentCharacter < characterList.Length)
            {
              Destroy(clone);
              clone = Instantiate(characterList[currentCharacter],new Vector3(-0.3f,0.02f,-5.4f),Quaternion.Euler(new Vector3(0, 180, 0)));
            }
            else {
              Destroy(clone);
              currentCharacter = 0;
              clone = Instantiate(characterList[currentCharacter],new Vector3(-0.3f,0.02f,-5.4f),Quaternion.Euler(new Vector3(0, 180, 0)));
            }
          }

          if (Input.GetKeyDown(KeyCode.Return))
          {
            SceneManager.LoadScene("Main Scene");
          }

        }
      }
}
