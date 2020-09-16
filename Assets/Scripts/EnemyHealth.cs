using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f; 

    public void TakeDamage(float damage)
    {
        // This is able to calla  method in the gamobject that is attached to
        BroadcastMessage("OnDamageTaken"); 
        hitPoints -= damage; 
        if(hitPoints <= 0)
        {
            // Destroy the game object if hitpoints is less than 0 
            // the object that is attached to 

            Destroy(gameObject); 

        }
    }
}
