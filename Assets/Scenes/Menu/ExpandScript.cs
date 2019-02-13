using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandScript : MonoBehaviour
{

    public GameObject ExpandMenu, MenuBack, MenuVMinus, MenuVPlus, MenuVolume;

    // Start is called before the first frame update
    void Start()
    {
       
        //Buttons must be referenced as game objects to use setActive, etc.
        ExpandMenu = GameObject.Find("ExpandMenu");
        MenuBack = GameObject.Find("MenuBack");
        MenuVMinus = GameObject.Find("MenuVMinus");
        MenuVPlus = GameObject.Find("MenuVPlus");
        MenuVolume = GameObject.Find("MenuVolume");

        //Menu buttons begin inactive
        MenuBack.SetActive(false);
        MenuVPlus.SetActive(false);
        MenuVMinus.SetActive(false);
        MenuVolume.SetActive(false);
    }

    public void OnExpandClick()
    {
        Debug.Log("Expand button pressed.");
        ExpandMenu.SetActive(false);
        MenuBack.SetActive(true);
        MenuVPlus.SetActive(true);
        MenuVMinus.SetActive(true);
        MenuVolume.SetActive(true);
    }

    public void OnBackClick()
    {
        Debug.Log("Back button pressed.");
        MenuBack.SetActive(false);
        MenuVPlus.SetActive(false);
        MenuVMinus.SetActive(false);
        MenuVolume.SetActive(false);
        ExpandMenu.SetActive(true);
    }

    public void OnVMinusClick()
    {
        Debug.Log("Decrease Volume.");
    }

    public void OnVPlusClick()
    {
        Debug.Log("Increase Volume.");
    }

    public void OnVolumeClick()
    {
        Debug.Log("Volume Pressed, Toggle Mute.");
    }
}
