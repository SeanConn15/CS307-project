using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialog_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Animator anim1 = other.GetComponent<Animator>();
            Animator anim2 = GameObject.Find("NPC").GetComponent<Animator>();
            anim1.SetTrigger("Wave");
            anim2.SetTrigger("Wave");

            Debug.Log("Hello friend!");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Goodbye!");
        }
    }
}
