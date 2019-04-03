//Made by: Sean Connelly
//Purpose: Controlls the actions of the cannon for game three room one

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLogic : MonoBehaviour
{
    public int reaction_speed = 10;
    public int range = 10;

    private GameObject player;
    private Vector3 cannon_position;
    private Transform cannon_object;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        cannon_position = transform.position;
        foreach(Transform child in transform)
        {
            if (child.name == "Cannon")
                cannon_object = child;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //if in range, rotate the cannon closer
        if (Vector3.Distance(cannon_position, player.transform.position) <= range)
        {
            Debug.Log("Bang!");
        }
            //if the cannon is looking at the player (within a threshold) spawn a cannon object with a force
    }
}
