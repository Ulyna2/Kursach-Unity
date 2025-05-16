using UnityEngine;

public class ShootingFlyingEnemy : ShootingEnemy
{
    [SerializeField] private float moveSpeed = 2f;

    protected override void Update()
    {
        base.Update();

        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance > 0.5f)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }

        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * (player.transform.position.x > transform.position.x ? 1 : -1);
        transform.localScale = scale;
    }
}

