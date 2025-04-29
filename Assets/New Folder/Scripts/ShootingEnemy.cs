using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public GameObject lightballPrefab;       // Префаб светового шара врага
    public Transform shootPoint;             // Точка, откуда летит снаряд
    public float shootingInterval = 2f;      // Пауза между выстрелами
    public float detectionRadius = 6f;       // Радиус, в котором враг начинает стрелять
    public int health = 3;                   // Кол-во жизней врага
    public float projectileSpeed = 5f;

    private GameObject player;
    private float shootTimer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shootTimer = shootingInterval;
    }

    private void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.transform.position);
        shootTimer -= Time.deltaTime;

        if (distance <= detectionRadius && shootTimer <= 0f)
        {
            ShootAtPlayer();
            shootTimer = shootingInterval;
        }
    }

    private void ShootAtPlayer()
    {
        GameObject projectile = Instantiate(lightballPrefab, shootPoint.position, Quaternion.identity);
        Vector2 direction = (player.transform.position - shootPoint.position).normalized;
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
