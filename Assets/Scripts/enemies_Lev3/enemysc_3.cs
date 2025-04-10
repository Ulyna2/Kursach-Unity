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
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            levelManager.EnemyKilled();
        }
        


    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Боковое столкновение!  Отнимаем жизнь у игрока.
            hero player = collision.gameObject.GetComponent<hero>();

            if (player != null)
            {
                player.LoseLife();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            levelManager.EnemyKilled();


        }
    }

}