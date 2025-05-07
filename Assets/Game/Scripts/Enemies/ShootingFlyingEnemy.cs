using UnityEngine;

public class ShootingFlyingEnemy : ShootingEnemy
{
    [SerializeField] private float moveSpeed = 2f;

    protected override void Update()
    {
        base.Update(); // Вызов логики стрельбы из базового класса

        if (player == null) return;

        // Движение к игроку
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance > 0.5f)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }

        // Поворот к игроку
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * (player.transform.position.x > transform.position.x ? 1 : -1);
        transform.localScale = scale;
    }
}

