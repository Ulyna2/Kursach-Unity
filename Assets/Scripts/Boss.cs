using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public float speed = 0.03f;
    
    public float startX;
    public float endX;
    private bool movingToEnd = true;

    public int hitsToKill = 10;
    private int currentHits = 0;

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
        if (collision.gameObject.CompareTag("Player"))
        {
            ContactPoint2D contact = collision.GetContact(0);

            if (contact.normal.y < -0.5f)
            {
                // ����� ������ ��������� �� �����
                currentHits++;
                Debug.Log("���� ������� ����! ������: " + currentHits);

                if (currentHits >= hitsToKill)
                {
                    Die();
                }

                // ������������ ������ �����
                Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                    playerRb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
                }
            }
            else
            {
                // ����� �������� ����� � ������������� �����
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void Die()
    {
        Debug.Log("���� ��������!");
        Destroy(gameObject);

        // ��������� ��������� �������
        SceneManager.LoadScene(3); // �������, ��� Level2 = ������ 3
    }
}
