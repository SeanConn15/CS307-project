using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAudio : MonoBehaviour
{

    public AudioClip menuClip;
    public AudioSource menuSource;

    // Start is called before the first frame update
    void Start()
    {
        menuSource.clip = menuClip;
        menuSource.Play();
    }
}
