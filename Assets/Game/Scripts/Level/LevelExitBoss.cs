using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExitBoss : MonoBehaviour
{
    [SerializeField] private string nextLevelName;
    [SerializeField] private string previousSceneName;
    private PlayerMovement player;

    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.GetComponent<PlayerMovement>();

    }
    private void Update()
    {
        if (player != null && player.currentLives <= 0)
        {
            Debug.Log("Игрок проиграл. Возврат к предыдущему уровню.");
            SceneManager.LoadScene(previousSceneName);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& player.currentLives > 0)
        {
            if (IsBossDefeated())
            {
                Debug.Log("Босс побежден. Переход к следующему уровню.");
                SceneManager.LoadScene(nextLevelName);
            }
            else
            {
                Debug.Log("Сначала победи босса!");
            }
        }
    }

    private bool IsBossDefeated()
    {
        GameObject boss = GameObject.FindWithTag("Enemy");
        return boss == null; // если объекта нет — значит он побежден
    }
}

