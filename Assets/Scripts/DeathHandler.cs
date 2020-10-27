using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas; 

    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.enabled = false; 
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        // freeze time when player is dead
        Time.timeScale = 0;
        // disable switching of weapons when dead
        FindObjectOfType<WeaponSwitcher>().enabled = false; 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; 
    }
    
}
