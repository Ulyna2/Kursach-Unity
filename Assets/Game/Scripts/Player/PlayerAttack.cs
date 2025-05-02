using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttac : MonoBehaviour
{
    [SerializeField] private float attackCooldown;   
    [SerializeField] private Transform lightPoint;
    [SerializeField] private GameObject[] lightballs;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float attackRadius;


    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        lightballs[FindLightball()].transform.position = lightPoint.position;
        lightballs[FindLightball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(lightPoint.position, attackRadius, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            IDamageable damageable = enemy.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage();
            }
        }
    }

    private int FindLightball()
    {
        for (int i = 0; i < lightballs.Length; i++)
        {
            if (!lightballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
