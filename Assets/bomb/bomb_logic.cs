using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_logic : MonoBehaviour
{
    // Start is called before the first frame update
    bool exploded;
    void Start()
    {
        exploded = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && !exploded)
        {
            Debug.Log("a bomb has appeared");
            GameObject.Find("Player").GetComponent<Animator>().SetTrigger("Wave");
            GameObject.Find("explosion").GetComponent<Animator>().SetTrigger("Explode");
            exploded = true;
        }
    }
    void OnTriggerExit(Collider other)
    {

    }
}
