using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomProjectile : MonoBehaviour
{
    //Assignables
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask whatIsEnemies;

    //Stats
    [Range(0f, 1f)]
    public float bounciness;
    public bool useGravity;

    //Damage
    public int explosionDamage;
    public float explosionRange;
    public float explosionForce;

    //Lifetime
    public int maxCollisions;
    public float maxLifetime;
    public bool explodeOnTouch = true;

    int collisions;
    PhysicMaterial physics_mat;
    // Start is called before the first frame update
    void Start()
    {
        Setup();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        //When to explode
        if(collisions < maxCollisions)
        {
            Explode();
        }

        //Count down lifetime
        maxLifetime -= Time.deltaTime;
        if(maxLifetime <= 0)
        {
            Explode();
        }
    }

    private void Explode()
    {
        //Instantiate explosion
        if(explosion != null)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
        }

        //Check for enemies
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, whatIsEnemies);
        for(int i = 0; i < enemies.Length; i++)
        {
            //Get component of enemy and call Take Damage
            enemies[i].GetComponent<EnemyBehavior>().TakeDamage(explosionDamage);

            //Add explosion force (if enemy has a rigidbody)
            if (enemies[i].GetComponent<Rigidbody>())
            {
                enemies[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRange);

            }

            //Add delay
            Invoke("Delay", 0.05f);
        }
    }

    private void Delay()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Increase collisions
        collisions++;

        if (collision.collider.CompareTag("Enemy") && explodeOnTouch)
        {
            Explode();
        }
    }

    private void Setup()
    {
        //Create a new Physic material
        physics_mat = new PhysicMaterial();
        physics_mat.bounciness = bounciness;
        physics_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physics_mat.bounceCombine = PhysicMaterialCombine.Maximum;
        //Assign material to collider
        GetComponent<SphereCollider>().material = physics_mat;

        //Set gravity
        rb.useGravity = useGravity;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, explosionRange);
    }
}
