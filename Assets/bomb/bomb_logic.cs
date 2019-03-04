using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_logic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("a bomb has appeared");
            GameObject.Find("Player").GetComponent<Animator>().SetTrigger("Wave");
        }
    }
    void OnTriggerExit(Collider other)
    {

    }
}
