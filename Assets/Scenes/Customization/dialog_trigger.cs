using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialog_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    GameObject NPC;
    GameObject dialog;
    private void Start()
    {
        player = GameObject.Find("Player");
        NPC = GameObject.Find("NPC");
        dialog = GameObject.Find("Dialog");
        dialog.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            //Animator anim1 = player.GetComponent<Animator>();
            Animator anim2 = NPC.GetComponent<Animator>();
            //anim1.SetTrigger("Wave");
            anim2.SetTrigger("Wave");
            dialog.SetActive(true);

            Debug.Log("Hello friend!");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            dialog.SetActive(false);
            Debug.Log("Goodbye!");
        }
    }
}
