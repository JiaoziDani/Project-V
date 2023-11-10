using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    
    public bool canPickUp = false;

    /*  Weapon Pickup
     *      Collision Triggered
     *      Uses Collider to create a weapon's "pick up zone"
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Set boolean to true when player ENTERS pick up zone
            canPickUp = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if  (other.CompareTag("Player"))
        {
            // Set boolean to false when player LEAVES pick up zone
            canPickUp = false;
        }
    }

    private void Update()
    {
        
        if (canPickUp && )
    }
}
