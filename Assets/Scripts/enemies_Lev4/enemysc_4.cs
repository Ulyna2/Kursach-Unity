using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.SceneManagement; 
 
 
public class enemysc_4 : MonoBehaviour 
{ 
    public LevelManager levelManager; 
 
    private void OnCollisionEnter2D(Collision2D collision) 
    { 
        if (collision.gameObject.tag == "Player") 
        { 
            SceneManager.LoadScene(4); 
        } 
    } 
    private void OnTriggerEnter2D(Collider2D collision) 
    { 
        if (collision.gameObject.tag == "Player") 
        { 
             
            Destroy(gameObject); 
            levelManager.EnemyKilled(); 
 
        } 
         
    } 
}