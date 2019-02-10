// Aurthor: Jisoo Cha
// Purpose: When press up arrow key, camera move to the portal and change scene.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoMove : MonoBehaviour
{
    public Canvas text;
    CameraMove cameraM;
    public bool changeScene = false;
    int i = 0;

    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("CameraMove");
        cameraM = gameController.GetComponent<CameraMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (changeScene)
        {
            text.gameObject.SetActive(false);
            transform.Translate(cameraM.moveVecor * cameraM.moveSpeed * Time.deltaTime);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("portal"))
        {
            changeScene = true;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
