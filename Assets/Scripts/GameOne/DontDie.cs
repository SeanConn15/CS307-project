using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Xingyu Wang
// make sure music will not be interrupted when scene get reloaded
// make sure only one music is playing

public class DontDie : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
}
