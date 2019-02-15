//Christian Bortolotti
//Main Script for the menu buttons/interfacing

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandScript : MonoBehaviour
{

    public GameObject ExpandMenu, MenuBack, MenuVMinus, MenuVPlus, MenuVolume, MenuResolution, MenuSE;
    public AudioSource menuAdjust;
    float VolAdjustValue = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
       
        //Buttons must be referenced as game objects to use setActive, etc.
        ExpandMenu = GameObject.Find("ExpandMenu");
        MenuBack = GameObject.Find("MenuBack");
        MenuVMinus = GameObject.Find("MenuVMinus");
        MenuVPlus = GameObject.Find("MenuVPlus");
        MenuVolume = GameObject.Find("MenuVolume");
        MenuResolution = GameObject.Find("MenuResolution");
        MenuSE = GameObject.Find("MenuSE");

        //Menu buttons begin inactive
        MenuBack.SetActive(false);
        MenuVPlus.SetActive(false);
        MenuVMinus.SetActive(false);
        MenuVolume.SetActive(false);
        MenuResolution.SetActive(false);
        MenuSE.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ExpandMenu.activeSelf)
            {
                OnExpandClick();
            }
            else
            {
                OnBackClick();
            }
            
        }
    }

    public void OnExpandClick()
    {
        Debug.Log("Expand button or escape key pressed.");
        ExpandMenu.SetActive(false);
        MenuBack.SetActive(true);
        MenuVPlus.SetActive(true);
        MenuVMinus.SetActive(true);
        MenuVolume.SetActive(true);
        MenuResolution.SetActive(true);
        MenuSE.SetActive(true);
    }

    public void OnBackClick()
    {
        Debug.Log("Back button or escape key pressed.");
        MenuBack.SetActive(false);
        MenuVPlus.SetActive(false);
        MenuVMinus.SetActive(false);
        MenuVolume.SetActive(false);
        MenuResolution.SetActive(false);
        MenuSE.SetActive(false);
        ExpandMenu.SetActive(true);
    }

    public void OnVMinusClick()
    {
        Debug.Log("Decrease Volume.");

        //if muted, unmute before altering
        if (menuAdjust.mute)
        {
            menuAdjust.mute = false;
        }

        //decrease volume by VolAdjValue or to 0
        if (menuAdjust.volume - VolAdjustValue < 0)
        {
            menuAdjust.volume = 0;
        }
        else
        {
            menuAdjust.volume -= VolAdjustValue;
        }
    }

    public void OnVPlusClick()
    {
        Debug.Log("Increase Volume.");

        //if muted, unmute before altering
        if (menuAdjust.mute)
        {
            menuAdjust.mute = false;
        }

        //increase volume by VolAdjValue or to max
        if (menuAdjust.volume + VolAdjustValue > 1)
        {
            menuAdjust.volume = 1;
        }
        else
        {
            menuAdjust.volume += VolAdjustValue;
        }
    }

    public void OnVolumeClick()
    {
        Debug.Log("Volume Pressed, Toggle Mute.");
        menuAdjust.mute = !menuAdjust.mute;
    }

    public void OnResolutionClick()
    {
        Debug.Log("Resolution Adjustments desired.");
    }

    public void OnSaveExitClick()
    {
        Debug.Log("Save Exit button pressed.");
    }
}
