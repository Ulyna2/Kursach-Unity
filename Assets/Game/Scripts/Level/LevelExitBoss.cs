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
            SceneManager.LoadScene(previousSceneName);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& player.currentLives > 0)
        {
            if (IsBossDefeated())
            {
                SceneManager.LoadScene(nextLevelName);
            }
        }
    }

    private bool IsBossDefeated()
    {
        GameObject boss = GameObject.FindWithTag("Enemy");
        return boss == null;
    }
}

