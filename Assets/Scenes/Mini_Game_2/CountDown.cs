//Christian Bortolotti - Countdown script for the final part of game2

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{

    public Text CountDownTime;
    bool x = true;
    bool active = true;
    float s;
    [SerializeField] private float timeLimit;
    [SerializeField] public float Radius;
    public GameObject Canvas1;
    public GameObject Player;
    public GameObject Exit;

    // Start is called before the first frame update
    void Start()
    {
        s = timeLimit;
        Canvas1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector3.Distance(Player.transform.position, Exit.transform.position) < Radius)
        {
            active = false;
            CountDownTime.text = "";
            Canvas1.SetActive(false);
        }
        if (active)
        {
            if (s >= 0.0f)
            {
                s -= Time.deltaTime;
                CountDownTime.text = s.ToString("F");
            }
            else
            {
                //Debug.Log("Time Ended, Reload.");
                if (s < 0.0f && x)
                {
                    Doom();
                    x = false;
                }
            }
        }
    }

    //IEnumerator Doom()
    void Doom()
    {
        //yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Final");
    }
}
