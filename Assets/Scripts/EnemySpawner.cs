using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private BoxCollider coll;

    public Transform spawnPoint;
    public GameObject[] enemies;
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

    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player" && !isTriggered)
        {
            isTriggered = true;
            InvokeRepeating("SpawnEnemy", 0.2f, rate);
            coll.enabled = false;
        }

        //Destroy(gameObject);

    }
    void SpawnEnemy()
    {
        Instantiate(enemies[(int)Random.Range(0, enemies.Length)], spawnPoint.position, spawnPoint.rotation);
    }

    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        CancelInvoke();
        isTriggered = false;
    }
    */
}
