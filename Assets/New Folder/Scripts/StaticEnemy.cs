using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Player"))
    {
        PlayerMovement player = collision.GetComponent<PlayerMovement>();
        if (player != null)
        {
            // Проверка: игрок выше врага
            float playerBottom = collision.bounds.min.y;
            float enemyTop = GetComponent<Collider2D>().bounds.max.y;

            if (playerBottom > enemyTop - 0.1f)
            {
                Destroy(gameObject); // Враг умирает
            }
            else
            {
                player.LoseLife(); // Игрок теряет жизнь
            }
        }
    }
}

}
