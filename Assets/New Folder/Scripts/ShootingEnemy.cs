using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform lightPoint;
    [SerializeField] private GameObject[] lightballs;
    //public GameObject lightballPrefab;  // Префаб светового шара врага
    //public Transform shootPoint;             // Точка, откуда летит снаряд
    //public float shootingInterval = 2f;      // Пауза между выстрелами
    public float detectionRadius = 6f;       // Радиус, в котором враг начинает стрелять
    public int health = 3;                   // Кол-во жизней врага
    //public float projectileSpeed = 5f;

    private GameObject player;
    //private float shootTimer;
    private float cooldownTimer = Mathf.Infinity;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //shootTimer = shootingInterval;
    }

    private void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.transform.position);
        //shootTimer -= Time.deltaTime;

        //if (distance <= detectionRadius && shootTimer <= 0f)
        if (distance <= detectionRadius && cooldownTimer > attackCooldown)
        {
            //ShootAtPlayer();
            //shootTimer = shootingInterval;
            Attack();
            cooldownTimer = 0; // Сброс cooldown после атаки
        }
        cooldownTimer += Time.deltaTime;
    }
    private void Attack()
    {
        int lightballIndex = FindLightball();
        if (lightballIndex != -1) // Проверка на наличие доступного lightball
        {
            lightballs[lightballIndex].transform.position = lightPoint.position;
            lightballs[lightballIndex].SetActive(true); // Активируем lightball
            lightballs[lightballIndex].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        }
        else
        {
            Debug.LogWarning("No available lightballs!");
        }
    }
    private int FindLightball()
    {
        for (int i = 0; i < lightballs.Length; i++)
        {
            if (!lightballs[i].activeInHierarchy)
                return i;
        }
        return -1; // Возвращаем -1, если все lightball активны
    }

    /*
    private void ShootAtPlayer()
    {
        GameObject projectile = Instantiate(lightballPrefab, shootPoint.position, Quaternion.identity);
        Vector2 direction = (player.transform.position - shootPoint.position).normalized;
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
    }*/

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
