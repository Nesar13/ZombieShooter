using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{


    [SerializeField] float hitPoints = 100f;

  
    
    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            // Destroy the game object if hitpoints is less than 0 
            // the object that is attached to 

            Debug.Log("You dead, my nig"); 

        }
    }
   
}
