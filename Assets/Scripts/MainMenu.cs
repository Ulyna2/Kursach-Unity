using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        PauseMenu.isGamePaused = false;
        SceneManager.LoadScene("Level_1"); 
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("Level_1");
        
    }

    public void ExitGame()
    {
        Debug.Log("Game Over!");
        Application.Quit();
    }
}
