using UnityEngine; 
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public bool keyCollected = false;
    public int totalEnemies;
    private int remainingEnemies;
    public Sprite emptyKeySprite;
    public Sprite fullKeySprite;
    public Image keyImage;

    void Start()
    {
        // Подсчитываем количество врагов в сцене 
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        totalEnemies = enemies.Length; // Обновляем totalEnemies 
        remainingEnemies = totalEnemies;
    }

    public void EnemyKilled()
    {
        remainingEnemies--;
        Debug.Log("Осталось врагов: " + remainingEnemies);
    }

    public bool AllEnemiesKilled()
    {
        return remainingEnemies == 0;
    }
    public void KeyCollected()
    {
        keyCollected = true;
        Debug.Log("Ключ собран!");
        keyImage.sprite = fullKeySprite;


    }
}