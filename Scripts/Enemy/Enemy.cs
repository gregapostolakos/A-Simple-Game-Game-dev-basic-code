using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    public int currentHealth;
    public EnemyHealthBar healthBar;
    public GameObject quitHealth;
    public static bool isQuit = true;
    public SpriteRenderer sr;
    public GameObject moveSpot;
    public GameObject moveSpot1;




    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        healthBar.SetHealth(currentHealth);

        if(currentHealth < maxHealth)
        {
            sr.flipX = false;
            animator.SetBool("IsFollowing", true);
            Destroy(moveSpot);
            Destroy(moveSpot1);
        }

        if (currentHealth <= 0)
        {
            Die();
        }

    }

     public void Update()
    {
        healthBar.HealthFlip();
    }




    void Die()
    {
        quitHealth.SetActive(false);
        Time.timeScale = 1f;
        isQuit = true;

        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

    }

}
