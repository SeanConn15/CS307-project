using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandScript : MonoBehaviour
{

    public Button ExpandMenu;

    // Start is called before the first frame update
    void Start()
    {
        ExpandMenu.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TaskOnClick()
    {
        Debug.Log("Expand button pressed");
    }
}
