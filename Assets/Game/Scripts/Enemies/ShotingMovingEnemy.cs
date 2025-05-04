using UnityEngine;

public class ShootingMovingEnemy : MonoBehaviour, IDamageable
{
    [Header("Movement")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance = 1f;
    private bool movingRight = true;
    private Rigidbody2D body;

    [Header("Shooting")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform lightPoint;
    [SerializeField] private GameObject[] lightballs;
    public float detectionRadius = 6f;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Health")]
    public int maxHealth = 3;
    private int currentHealth;

    private GameObject player;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.gravityScale = 0; // Чтобы не падал
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentHealth = maxHealth;
    }

    private void Update()
    {
        Patrol();
        HandleAttack();
    }

    private void Patrol()
    {
        body.velocity = new Vector2((movingRight ? 1 : -1) * speed, 0f);

        Vector2 checkPosition = groundCheck.position;
        RaycastHit2D hit = Physics2D.Raycast(checkPosition, Vector2.down, groundCheckDistance, groundLayer);

        Debug.DrawRay(checkPosition, Vector2.down * groundCheckDistance, Color.red);

        if (!hit.collider)
            Flip();
    }

    private void Flip()
    {
        movingRight = !movingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void HandleAttack()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance <= detectionRadius && cooldownTimer > attackCooldown)
        {
            Attack();
            cooldownTimer = 0;
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        int lightballIndex = FindLightball();
        if (lightballIndex != -1)
        {
            lightballs[lightballIndex].transform.position = lightPoint.position;
            lightballs[lightballIndex].SetActive(true);
            lightballs[lightballIndex].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        }
    }

    private int FindLightball()
    {
        for (int i = 0; i < lightballs.Length; i++)
        {
            if (!lightballs[i].activeInHierarchy)
                return i;
        }
        return -1;
    }

    public void TakeDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Projectile>())
        {
            TakeDamage();
        }

        if (collision.CompareTag("Player"))
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            if (player != null)
                player.LoseLife();
        }
    }
}
