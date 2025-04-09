using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DinamicEnemy_5 : MonoBehaviour
{
    public LevelManager levelManager;
    public float speed = 0.03f;
    public float startX;
    public float endX;
    private bool movingToEnd = true;

    public void Start()
    {
        transform.position = new Vector3(startX, transform.position.y, transform.position.z);
    }

    public void FixedUpdate()
    {
        float targetX = movingToEnd ? endX : startX;
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed);

        if (Mathf.Abs(transform.position.x - targetPosition.x) < 0.01f)
        {
            movingToEnd = !movingToEnd;

            transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(5);
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
