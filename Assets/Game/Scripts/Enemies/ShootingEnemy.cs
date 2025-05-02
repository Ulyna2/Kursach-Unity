using UnityEngine;


public class ShootingEnemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform lightPoint;
    [SerializeField] private GameObject[] lightballs;
   
    public float detectionRadius = 6f;       // Радиус, в котором враг начинает стрелять
    //public int health = 3;                   // Кол-во жизней врага
    public int maxHealth = 3; // Максимальное здоровье
    private int currentHealth; // Текущее здоровье


    private GameObject player;
  
    private float cooldownTimer = Mathf.Infinity;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentHealth = maxHealth;

    }

    private void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.transform.position);
        
        if (distance <= detectionRadius && cooldownTimer > attackCooldown)
        {
            
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

    
    public void TakeDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
