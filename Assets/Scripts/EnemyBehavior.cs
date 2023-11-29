using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask whatIsGround, whatIsPlayer;

    [SerializeField] private float health;

    //Patrolling
    [SerializeField] private Vector3 walkpoint;
    [SerializeField] private bool walkPointSet;
    [SerializeField] private float walkPointRange;

    //Attacking
    [SerializeField] private float timeBetweenAttacks;
    [SerializeField] private bool alreadyAttacked;
    public GameObject projectile;
    [SerializeField] private bool canShoot;

    //States
    [SerializeField] private float sightRange, attackRange;
    [SerializeField] private bool playerInSightRange, playerInAttackRange;

    public EnemySpawner spawner;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        spawner = GameObject.Find("Spawner").GetComponent<EnemySpawner>();
        agent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patrolling();
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        if (playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
        }
    }

    public void Patrolling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkpoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkpoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkpoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkpoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    public void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    public void AttackPlayer()
    {
        //Make sure enemy doesnt move
        //agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            if(canShoot)
            {
                //Shooting code
                agent.SetDestination(transform.position);

                Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
                rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            }
            else
            {
                //Melee Code
            }

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            Invoke(nameof(Die), .5f);
        }
    }

    private void Die()
    {
        spawner.DecreaseEnemiesAlive();
        Destroy(gameObject);
    }
}
