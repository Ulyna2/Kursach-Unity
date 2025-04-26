using UnityEngine;

public class FlyingEnemy_5 : MonoBehaviour
{
    public float speed = 2f;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hero playerScript = collision.GetComponent<hero>();
            if (playerScript != null)
            {
                playerScript.LoseLife();
            }
        }
    }
}
