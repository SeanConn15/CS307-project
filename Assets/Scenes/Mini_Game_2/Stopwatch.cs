//Christian Bortolotti - A(n overengineered) Stopwatch script that cleanly displays the time elapsed

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{

    public Text StopwatchTime;
    float s, m;

    // Start is called before the first frame update
    void Start()
    {
        StopwatchTime.text = "00:00";
    }

    // Update is called once per frame
    void Update()
    {
        s += Time.deltaTime;
        if (s >= 60)
        {
            s = 0;
            m++;
        }
        if (s > 10)
        {
            if (m < 10)
            {
                StopwatchTime.text = "0" + ((int)m).ToString() + ":" + ((int)s).ToString();
            }
            else
            {
                StopwatchTime.text = ((int)m).ToString() + ":" + ((int)s).ToString();
            }
        }
        else
        {
            if (m < 10)
            {
                StopwatchTime.text = "0" + ((int)m).ToString() + ":0" + ((int)s).ToString();
            }
            else
            {
                StopwatchTime.text = ((int)m).ToString() + ":0" + ((int)s).ToString();
            }
            
        }
    }
}
