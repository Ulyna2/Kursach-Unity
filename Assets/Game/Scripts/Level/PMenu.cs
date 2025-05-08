using UnityEngine;
using UnityEngine.SceneManagement;

public class PMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public void OpenPauseMenu()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0); // Убедись, что сцена названа верно
    }
}
