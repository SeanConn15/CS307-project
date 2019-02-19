//Christian Bortolotti
//Main Script for the menu buttons/interfacing

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExpandScript : MonoBehaviour
{

    public Animator menu_back_enter, menu_volume_enter, menu_vplus_enter, menu_vminus_enter, 
        menu_resolution_enter, menu_se_enter, menu_resmin_enter, menu_resplus_enter;
    public GameObject ExpandMenu, MenuBack, MenuVMinus, MenuVPlus, MenuVolume,
        MenuResolution, MenuSE, MenuResMinus, MenuResPlus;
    public AudioSource menuAdjust;
    float VolAdjustValue = 0.2f;

    private const string RESOLUTION_PREF_KEY = "resolution";


    [SerializeField]
    private Text resolutionText;
    private Resolution[] resolutions;
    private int currentResolutionIndex = 0;


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
        MenuResMinus = GameObject.Find("MenuResMinus");
        MenuResPlus = GameObject.Find("MenuResPlus");
        MenuSE = GameObject.Find("MenuSE");

        resolutions = Screen.resolutions;
        currentResolutionIndex = PlayerPrefs.GetInt(RESOLUTION_PREF_KEY, 0);
        SetResolutionText(resolutions[currentResolutionIndex]);

        //Menu buttons begin inactive
        MenuBack.SetActive(false);
        MenuVPlus.SetActive(false);
        MenuVMinus.SetActive(false);
        MenuVolume.SetActive(false);
        MenuResolution.SetActive(false);
        //MenuResMinus.SetActive(false);
        //MenuResPlus.SetActive(false);
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
        //MenuResMinus.SetActive(true);
        //MenuResPlus.SetActive(true);
        MenuSE.SetActive(true);


        menu_back_enter.SetBool("engage_back", true);
        menu_volume_enter.SetBool("engage_volume", true);
        menu_vplus_enter.SetBool("engage_vplus", true);
        menu_vminus_enter.SetBool("engage_vminus", true);
        menu_resolution_enter.SetBool("engage_resolution", true);
        menu_se_enter.SetBool("engage_saveexit", true);

        //Time.timeScale = 0;

    }

    public void OnBackClick()
    {
        Debug.Log("Back button or escape key pressed.");

        menu_back_enter.SetBool("engage_back", false);
        menu_volume_enter.SetBool("engage_volume", false);
        menu_vplus_enter.SetBool("engage_vplus", false);
        menu_vminus_enter.SetBool("engage_vminus", false);
        menu_resolution_enter.SetBool("engage_resolution", false);
        menu_se_enter.SetBool("engage_saveexit", false);

        //MenuBack.SetActive(false);
        //MenuVPlus.SetActive(false);
        //MenuVMinus.SetActive(false);
        //MenuVolume.SetActive(false);
        //MenuResolution.SetActive(false);
        //MenuSE.SetActive(false);
        ExpandMenu.SetActive(true);

        //Time.timeScale = 1;
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

    public void OnMainMenuClick()
    {
        //Application.LoadLevel("Main Scene");
        SceneManager.LoadScene("Main Scene");
        
    }

    public void OnVolumeClick()
    {
        Debug.Log("Volume Pressed, Toggle Mute.");
        menuAdjust.mute = !menuAdjust.mute;
    }

    public void OnResolutionClick()
    {
        Debug.Log("Toggle Full-Screen and Window");
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void OnSaveExitClick()
    {
        Debug.Log("Save Exit button pressed.");
        Application.Quit();
    }

    private void SetResolutionText(Resolution resolution)
    {
        resolutionText.text = resolution.width + "x" + resolution.height;
    }
    public void SetNextResolution()
    {
        currentResolutionIndex = GetNextWrappedIndex(resolutions, currentResolutionIndex);
        SetResolutionText(resolutions[currentResolutionIndex]);
    }
    public void SetPreviousResolution()
    {
        currentResolutionIndex = GetPreviousWrappedIndex(resolutions, currentResolutionIndex);
        SetResolutionText(resolutions[currentResolutionIndex]);
    }

    private void SetAndApplyResolution(int newResolutionIndex)
    {
        currentResolutionIndex = newResolutionIndex;
        ApplyCurrentResolution();
    }
    private void ApplyCurrentResolution()
    {
        ApplyResolution(resolutions[currentResolutionIndex]);
    }
    private void ApplyResolution(Resolution resolution)
    {
        SetResolutionText(resolution);
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt(RESOLUTION_PREF_KEY, currentResolutionIndex);
    }

    public void ApplyChanges()
    {
        SetAndApplyResolution(currentResolutionIndex);
    }

    // Helper functions
    private int GetNextWrappedIndex<T>(IList<T> collection, int currentIndex) // will get Next index or beginning of array
    {
        if (collection.Count < 1) return 0;
        return (currentIndex + 1) % collection.Count;
    }
    private int GetPreviousWrappedIndex<T>(IList<T> collection, int currentIndex) // will get Prev index or last of array
    {
        if (collection.Count < 1) return 0;
        if ((currentIndex - 1) < 0) return collection.Count - 1;
        return (currentIndex - 1) % collection.Count;

    }
}
