using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private string nextLevelName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null && player.hasKey)
            {
                Debug.Log("Переход на следующий уровень");
                SceneManager.LoadScene(nextLevelName);
            }
            else
            {
                Debug.Log("Нужен ключ для перехода!");
            }
        }
    }
}
