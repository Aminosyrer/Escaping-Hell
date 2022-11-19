using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // change scenes

public class MainMenu : MonoBehaviour
{
    // start the game
    public void PlayGame()
    {
        // loads next level in queue
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //quit the game
    public void QuitGame()
    {
        //Debug.Log tjekker om spillet quitter
        Debug.Log("QUIT");
        Application.Quit();
    }
    
}
