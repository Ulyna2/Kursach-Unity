using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DinamicEnemy_2 : MonoBehaviour
{    
    public LevelManager levelManager;
    public float speed = 0.03f;    
    public Vector3[] positions;
    private int currentTarget;
    public void FixedUpdate()
    {        
        transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget], speed);
        if (transform.position == positions[currentTarget])        
        {
            if (currentTarget < positions.Length - 1)            
            {
                currentTarget++;
            }            
            else
            {                
                currentTarget = 0;            
            }
        }  
    }

    private void OnCollisionEnter2D(Collision2D collision)    
    {
        if (collision.gameObject.tag == "Player")        
        {
            SceneManager.LoadScene(2);        
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