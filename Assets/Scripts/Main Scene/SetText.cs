//Author: Haoran Wang
//Purpose: get player text input and show output

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SetText : MonoBehaviour
{

    public InputField name;
    public InputField major;
    public InputField year;
    public Text fText;

    public void setget()
    {
      fText.text = "Hi there!" + "\nName: " + name.text + "\nMajor: " + major.text + "\nYear:" + year.text;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
