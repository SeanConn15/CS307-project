using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class converyor_logic : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.0f;
    void Start()
    {
        
    }
    void OnTriggerStay(Collider other)
    {

        //Debug.Log("converyor belt force");
        other.GetComponent<Rigidbody>().AddForce(transform.forward * speed);

    }
    // Update is called once per frame
    void Update()
    {
        //get the third child component of this object (the texture on the top of the conveyor)
        //and set it's texture offset to move foreward using time as a modulus
        //the speed of the texture and player movement dont line up completely, so I eyeballed it
        this.transform.GetChild(2).GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, (Time.time * speed/9));
    }
}
