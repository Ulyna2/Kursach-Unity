using UnityEngine;

public class ShootingEnemy : MonoBehaviour, IDamageable
{
    [SerializeField] protected float attackCooldown;
    [SerializeField] protected Transform lightPoint;
    [SerializeField] protected GameObject[] lightballs;

    public float detectionRadius = 6f;
    public int maxHealth = 3;
    protected int currentHealth;

    protected GameObject player;
    protected float cooldownTimer = Mathf.Infinity;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentHealth = maxHealth;
    }

    protected virtual void Update()
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

    protected virtual void Attack()
    {
        int lightballIndex = FindLightball();
        if (lightballIndex != -1)
        {
            lightballs[lightballIndex].transform.position = lightPoint.position;
            lightballs[lightballIndex].SetActive(true);
            lightballs[lightballIndex].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        }
    }

    protected int FindLightball()
    {
        for (int i = 0; i < lightballs.Length; i++)
        {
            if (!lightballs[i].activeInHierarchy)
                return i;
        }
        return -1;
    }

    public virtual void TakeDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

