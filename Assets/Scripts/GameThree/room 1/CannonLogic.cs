//Made by: Sean Connelly
//Purpose: Controlls the actions of the cannon for game three room one

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLogic : MonoBehaviour
{
    public float reaction_speed = 0.025f;
    public int range = 10;

    private GameObject player;
    private Vector3 cannon_position;
    private Transform barrel;
    private Quaternion targetRotation;
    private GameObject ball;
    private float lastFire;
    private Transform spawn;

    // Start is called before the first frame update
    void Start()
    {
        //find the player
        player = GameObject.Find("Player");

        //get the current position of the cannon
        cannon_position = transform.position;
        lastFire = Time.time;

        //ball is what is fired
        ball = GameObject.Find("cannonball");

        //barrel is what rotates, ballspawn is where cannonballs come from, find both of them
        foreach (Transform child in transform)
        {
            if (child.name == "Barrel")
            {
                barrel = child;
                foreach (Transform child2 in child)
                {
                    if (child2.name == "ballspawn")
                        spawn = child2;
                }
            }
            
        }


    }

    // Update is called once per frame
    void Update()
    {

        //if in range, rotate the cannon closer
        if (Vector3.Distance(cannon_position, player.transform.position) <= range)
        {

            targetRotation = Quaternion.LookRotation((player.transform.position - barrel.position).normalized); //find angle looks directly at the player

            targetRotation.x = 0; //keep the cannon level
            targetRotation.z = 0;

            barrel.rotation = Quaternion.Slerp(barrel.rotation, targetRotation, Mathf.Min(reaction_speed * Time.deltaTime, 1));//rotate towards it smoothly

            //checking whether or not to fire, every one second max and only if you are pointed close enough to the player
            if (Time.time - lastFire >= 1 && 
                Vector3.Dot((player.transform.position - cannon_position).normalized, barrel.forward) > .95)
            {
                lastFire = Time.time; //reset cooldown

                //spawn the ball
                Vector3 spawnpoint = spawn.position;
                GameObject ballobj = Instantiate(ball, spawnpoint, Quaternion.identity);

                //give it a force
                ballobj.GetComponent<Rigidbody>().AddForce(barrel.forward * 1000);
            }

        }
    }
}
