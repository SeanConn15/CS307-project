//Christian Bortolotti
//Integration of UI Pause to Main Menu through Audio consolidation

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource UniversalAudioSource;
    public AudioClip[] clips;
    private int i = 0;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            i++;
            if (i >= clips.Length)
            {
                i = 0;
            }
            if (clips[i] != null)
            {
                UniversalAudioSource.clip = clips[i];
                UniversalAudioSource.Play();
                Debug.Log("Playing right arrow");
            }
            else
            {
                UniversalAudioSource.Stop();
                Debug.Log("Stopping right arrow");
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            i--;
            if (i < 0)
            {
                i = 0;
            }
            if (clips[i] != null)
            {
                UniversalAudioSource.clip = clips[i];
                UniversalAudioSource.Play();
                Debug.Log("Playing left arrow");
            }
            else
            {
                UniversalAudioSource.Stop();
                Debug.Log("Stopping left arrow");
            }
        }
    }
}
