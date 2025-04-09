using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.SceneManagement; 
 
public class Level1 : MonoBehaviour 
{ 
    public LevelManager levelManager; 
    public Transform finishPoint;  
 
    void OnTriggerEnter2D(Collider2D other) 
    { 
        if (other.gameObject == finishPoint.gameObject && levelManager.AllEnemiesKilled()) 
        { 
            SceneManager.LoadScene(2); 
        } 
        else 
        { 
            Debug.Log("Не все враги убиты, или вы не достигли финальной точки!"); 
        } 
    } 
}