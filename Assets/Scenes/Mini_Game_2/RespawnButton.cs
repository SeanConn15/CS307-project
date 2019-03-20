//Christian Bortolotti - Script to respawn using the respawn button

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class RespawnButton : MonoBehaviour
{

    public GameObject respawnButton;

    void Start()
    {
        respawnButton = GameObject.Find("Respawn");
    }

    // Start is called before the first frame update
    public void OnRespawnClicked()
    {
        Debug.Log("RESPAWN");
        SceneManager.LoadScene("game_2");
    }
}
