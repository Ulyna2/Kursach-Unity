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
                
                if (AreAllEnemiesDefeated())
                {
                    Debug.Log("������� �� ��������� �������");
                    SceneManager.LoadScene(nextLevelName);
                }
                else
                {
                    Debug.Log("������� ���� ���� ������!");
                }
            }
            else
            {
                Debug.Log("����� ���� ��� ��������!");
            }
        }
    }

    private bool AreAllEnemiesDefeated()
    {
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        return enemies.Length == 0;
    }
}