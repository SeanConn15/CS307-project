//Christian Bortolotti - A script that obtains the speed of the rigidbody and updates the HUD

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speed : MonoBehaviour
{

    public Text speedText = null;
    public Rigidbody carRB;
    private float tmp;
    int tmp2;

    // Start is called before the first frame update
    void Start()
    {
        //carRB = GetComponent<Rigidbody>();
        speedText.text = "";
        
    }

    // Update is called once per frame
    void Update()
    {
        tmp = carRB.velocity.magnitude;
        tmp2 = (int)tmp;
        speedText.text = tmp2.ToString() + " mph";
    }
}
