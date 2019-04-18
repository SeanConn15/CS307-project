using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //GameObject player;
    public Transform target;
    public GameObject[] Enemy;
    GameObject[] music;
    
    public Rigidbody m_rigidBody;

    Vector3 StartPoint;

    void Start()
    {
        StartPoint = transform.position;
        music = GameObject.FindGameObjectsWithTag("music"); // get music
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("Main Scene"); 
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Check"))
        {
            int i = 0;
            while (i < Enemy.Length - 1)
            {
                Enemy[i].gameObject.SetActive(true);
                i++;
            }
        }
        if (other.gameObject.CompareTag("Check2"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (other.gameObject.CompareTag("Check3"))
        {
            Enemy[Enemy.Length - 1].gameObject.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //transform.position = StartPoint;
        }
        if (collision.gameObject.CompareTag("MainPortal"))
        {
            Destroy(music[0]);   // Destory BackGround Music for Game One
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (collision.gameObject.CompareTag("Jumper"))
        {
            m_rigidBody.AddForce(Vector3.up * 13, ForceMode.Impulse);
        }
    }
}
