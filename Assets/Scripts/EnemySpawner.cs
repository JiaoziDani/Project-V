using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private BoxCollider coll;

    public Transform[] spawnPoints;
    public GameObject[] enemies;
    public int enemiesAlive;
    public int round;

    public int kills;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider>();
        enemiesAlive = 0;
        round = 0;
        kills = 0;
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

    public int GetRound() 
    {
        return round;
    }

    public void DecreaseEnemiesAlive()
    {
        --enemiesAlive;
    }

    public void RegisterKill() {
        ++kills;
    }

    public int GetKills() {
        return kills;
    }
}
