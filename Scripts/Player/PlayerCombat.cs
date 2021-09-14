using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;
    public LayerMask rangeEnemyLayers;
    public float attackRange = 0.5f;
    public int attackDamage = 5;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Attack");
                nextAttackTime = Time.time + 1f / attackRate;

            }
        }    
    }

    void Attack()
    {
        //Play an attack animation
        

        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        Collider2D[] hitRangeEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, rangeEnemyLayers);

        //Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
        foreach(Collider2D RangeEnemy in hitRangeEnemies)
        {
            RangeEnemy.GetComponent<RangeEnemy>().TakeDamage(attackDamage);
        }
    }

    

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
