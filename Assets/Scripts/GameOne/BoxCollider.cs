using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxCollider : MonoBehaviour
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
