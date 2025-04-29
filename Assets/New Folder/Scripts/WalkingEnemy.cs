using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck; // Пустой объект перед ногами врага
    [SerializeField] private float groundCheckDistance = 1f;

    private Rigidbody2D body;
    private bool movingRight = true;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.gravityScale = 0; // Отключаем падение
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        // Движение
        body.velocity = new Vector2((movingRight ? 1 : -1) * speed, 0f);

        // Проверка платформы перед врагом
        Vector2 checkPosition = groundCheck.position;
        RaycastHit2D hit = Physics2D.Raycast(checkPosition, Vector2.down, groundCheckDistance, groundLayer);

        Debug.DrawRay(checkPosition, Vector2.down * groundCheckDistance, Color.red);

        if (!hit.collider)
        {
            Flip();
        }
    }

    private void Flip()
    {
        movingRight = !movingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Убивается от светового шара
        if (collision.GetComponent<Projectile>())
        {
            Destroy(gameObject);
        }

        // Урон игроку
        if (collision.CompareTag("Player"))
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            if (player != null)
                player.LoseLife();
        }
    }
}
