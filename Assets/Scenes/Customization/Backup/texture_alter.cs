//Christian Bortolotti
//Script for switching between textures

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class texture_alter : MonoBehaviour
{

    public Texture[] textureBank;
    int currentTexture = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            OnRightArrow();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            OnLeftArrow();
        }
    }

    void OnRightArrow()
    {
        Debug.Log("Texture select right.");
        currentTexture++;
        if (currentTexture >= textureBank.Length)
        {
            currentTexture = 0;
        }
        //Renderer ren = GameObject.Find("Player").GetComponent<Renderer>();
        //ren.material.mainTexture = textureBank[currentTexture];
    }

    void OnLeftArrow()
    {
        Debug.Log("Texture select left.");
        currentTexture++;
        if (currentTexture >= textureBank.Length)
        {
            currentTexture = 0;
        }
        //Renderer ren = GameObject.Find("Player").GetComponent<Renderer>();
        //ren.material.mainTexture = textureBank[currentTexture];
    }
}
