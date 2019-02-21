//Aurthor: Sean Connelly
//Purpose: Control NPC logic/dialog

using UnityEngine;
using System.Collections;


public class dialog_logic1 : MonoBehaviour
{
    GameObject player;      //player character
    GameObject dialog;      //dialog menu
    GameObject dialog2;      //dialog menu
    GameObject indicator;   //next scene location indicator
    //called at beginning
    void Start()
    {
        player =    GameObject.Find("Player");
        dialog =    GameObject.Find("Dialog");
        dialog2 = GameObject.Find("Dialog 2");
        indicator = GameObject.Find("Indicator");

        dialog.SetActive(false);
        indicator.SetActive(false);
        dialog2.SetActive(false);
        GameObject.Find("NPC").GetComponent<Animator>().SetTrigger("Wave");
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
        dialog2.SetActive(true);
    }
}
