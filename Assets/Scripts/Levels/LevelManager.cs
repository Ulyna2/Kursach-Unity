using UnityEngine; 
using UnityEngine.SceneManagement; 
 
public class LevelManager : MonoBehaviour 
{ 
    public int totalEnemies; 
    private int remainingEnemies; 
 
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
}