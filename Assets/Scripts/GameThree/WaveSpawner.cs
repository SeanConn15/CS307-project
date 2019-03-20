using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
    public PlayerController p;
    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    [System.Serializable]
    public class Wave
    {
        public string name;
        //public Transform enemy;
        //public Transform iteam;
        public GameObject enemy;
        //public GameObject iteam;
        //public GameObject iteam2;
        public int count;
        public float rate;
        //public float iteamrate;
    }

    public Wave[] waves;
    private int nextWave = 0;
    private int c = 0;
    private int jump = 0;
    private int coo = 2;

    //public Transform[] spawnPoints;
    public GameObject[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("no spawn points");
        }

        waveCountdown = timeBetweenWaves;
    }
    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            
            else
            {
                return;
            }
        }
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("wave completed");
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;
        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("all waves complelt looping...");
        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyIsAlive()
    {
       searchCountdown -= Time.deltaTime;
        //if (Time.deltaTime <= searchCountdown)
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            // if (GameObject.FindGameObjectWithTag("Enemy") == null)
            if (p.count > coo)
            {
                coo = coo + 3;
                return false;
            }
        }
        else
        {
           // searchCountdown += 10f;
            return true;
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spwaning wave: " + _wave.name);
        state = SpawnState.SPAWNING;
       for (int i = 0; i < _wave.count; i++)
       {
           SpawnEnemy(_wave.enemy);
           yield return new WaitForSeconds(1f / _wave.rate);
       }

       /*
   while (true)
   {
       SpawnEnemy(_wave.enemy);
            if (_wave.iteamrate < c)
            {
                if (jump > 2)
                {
                    SpawnIteam(_wave.iteam2);
                    jump = 0;
                }
                else
                {
                    SpawnIteam(_wave.iteam);
                }

                jump++;
                c = 0;
            }
            c++;
       yield return new WaitForSeconds(1f / _wave.rate);
   }
   */
  
        state = SpawnState.WAITING;
        yield break;
    }
    //void SpawnEnemy(Transform _enemy)

    void SpawnEnemy(GameObject _enemy)
    {
        Debug.Log("Spwaning enemy: " + _enemy.name);
        _enemy.SetActive(true);
        GameObject _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.transform.position, _sp.transform.rotation);
    }
    /*
    void SpawnIteam(GameObject _iteam)
    {
        Debug.Log("Spwaning iteam: " + _iteam.name);
        _iteam.SetActive(true);
        GameObject _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_iteam, _sp.transform.position, _sp.transform.rotation);
    }
    */
}
