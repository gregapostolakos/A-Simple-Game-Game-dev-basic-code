using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeAttack : MonoBehaviour
{
    public Animator animator;

    public Transform strikePoint;
    public LayerMask enemyLayers;
    public LayerMask rangeEnemyLayers;
    public float attackRange = 0.5f;
    public int strikeDamage = 10;
    public float attackRate = 2f;
    float nextAttackTime = 0f;


    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                animator.SetTrigger("Strike");
                nextAttackTime = Time.time + 18f / attackRate;
            }
        }
    }

    void Strike()
    {
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(strikePoint.position, attackRange, enemyLayers);
        Collider2D[] hitRangeEnemies = Physics2D.OverlapCircleAll(strikePoint.position, attackRange, rangeEnemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(strikeDamage);
        }
        foreach (Collider2D RangeEnemy in hitRangeEnemies)
        {
            RangeEnemy.GetComponent<RangeEnemy>().TakeDamage(strikeDamage);
        }
    }
    void OnDrawGizmosSelected()
    {
        if (strikePoint == null)
            return;

        Gizmos.DrawWireSphere(strikePoint.position, attackRange);
    }
}

