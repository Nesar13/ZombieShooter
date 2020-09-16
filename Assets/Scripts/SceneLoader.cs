
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void ReloadGame() //Play again Button
    {
        SceneManager.LoadScene(0); //load scne with index 0
        // When dying, screen should be frozen
        // This is to set the time to start 
        Time.timeScale = 1; 
    }
    public void QuitGame()
    {
        Application.Quit(); //Quit Application
    }
}
