using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private BoxCollider coll;

    public Transform[] spawnPoints;
    public GameObject[] enemies;
    public int enemiesAlive = 0;
    public int round = 0;
    public float rate;
    public float lifeSpan;

    private bool isTriggered = false;


    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider>();
        //InvokeRepeating("SpawnEnemy", 0.2f, rate);

        // Destroy(gameObject, lifeSpan);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesAlive == 0)
        {
            round++;
            SpawnEnemies();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player" && !isTriggered)
        {
            isTriggered = true;
            InvokeRepeating("SpawnEnemies", 0.2f, rate);
            coll.enabled = false;
        }

        //Destroy(gameObject);

    }
    void SpawnEnemies()
    {
        //Instantiate(enemies[(int)Random.Range(0, enemies.Length)], spawnPoints[].position, spawnPoints[].rotation);
        /*
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(enemies[(int)Random.Range(0, enemies.Length)], spawnPoints[i].position, spawnPoints[i].rotation);
        }
        */

        for(int i = 0; i < round; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            Instantiate(enemies[(int)Random.Range(0, enemies.Length)], spawnPoint.position, spawnPoint.rotation);
            enemiesAlive++;
        }
    }

    public int GetEnemiesAlive()
    {
        return enemiesAlive;
    }
    public void SetEnemiesAlive(int enemiesAlive)
    {
        this.enemiesAlive = enemiesAlive;
    }
    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        CancelInvoke();
        isTriggered = false;
    }
    */
}
