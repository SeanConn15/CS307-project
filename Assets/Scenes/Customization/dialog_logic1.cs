//Aurthor: Sean Connelly
//Purpose: Control NPC logic/dialog

using UnityEngine;
using System.Collections;


public class dialog_logic1 : MonoBehaviour
{
    GameObject player;      //player character
    GameObject dialog;      //dialog menu
    GameObject indicator;   //next scene location indicator
    //called at beginning
    void Start()
    {
        player =    GameObject.Find("Player");
        dialog =    GameObject.Find("Dialog");
        indicator = GameObject.Find("Indicator");

        dialog.SetActive(false);
        indicator.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            dialog.SetActive(true);
            indicator.SetActive(true);
            GameObject.Find("NPC").GetComponent<Animator>().SetTrigger("Wave");
        }
    }
    void OnTriggerExit(Collider other)
    {
        dialog.SetActive(false);
    }
}
