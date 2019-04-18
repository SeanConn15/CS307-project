using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Author: Jisoo Cha
Main portal activates when player passes other portals
*/

namespace ttm{
public class TeleportToMain : MonoBehaviour
{
    public static bool portal1;
    public static bool portal2;
    public static bool portal3;
    public GameObject MainPortal;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(portal1 && portal2 && portal3){
            MainPortal.gameObject.SetActive(true);
        }
    }
}
}