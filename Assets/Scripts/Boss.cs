using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public float speed = 0.03f;
    public Vector3[] positions;
    private int currentTarget;

    public int hitsToKill = 10;
    private int currentHits = 0;

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
        if (collision.gameObject.CompareTag("Player"))
        {
            ContactPoint2D contact = collision.GetContact(0);

            if (contact.normal.y < -0.5f)
            {
                // Игрок сверху напрыгнул на босса
                currentHits++;
                Debug.Log("Босс получил удар! Ударов: " + currentHits);

                if (currentHits >= hitsToKill)
                {
                    Die();
                }

                // Отпрыгивание игрока вверх
                Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                    playerRb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
                }
            }
            else
            {
                // Игрок врезался сбоку — перезагружаем сцену
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void Die()
    {
        Debug.Log("Босс побежден!");
        Destroy(gameObject);

        // Загружаем следующий уровень
        SceneManager.LoadScene(3); // Убедись, что Level2 = индекс 3
    }
}
