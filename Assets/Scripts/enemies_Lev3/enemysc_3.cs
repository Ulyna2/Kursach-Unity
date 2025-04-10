using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.SceneManagement; 
 
 
public class enemysc_3 : MonoBehaviour 
{
    public LevelManager levelManager;
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (levelManager != null)
        {
            levelManager.EnemyKilled();
        }


    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            levelManager.EnemyKilled();
            
        }
    }
}