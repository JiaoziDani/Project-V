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

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider>();
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

    void SpawnEnemies()
    {

        for(int i = 0; i < round; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            Instantiate(enemies[(int)Random.Range(0, enemies.Length)], spawnPoint.position, spawnPoint.rotation);
            enemiesAlive++;
        }
    }

    public void DecreaseEnemiesAlive()
    {
        --enemiesAlive;
    }
}
