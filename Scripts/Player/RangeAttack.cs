using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject firePrefab;
    public float attackRate = 2f;
    float nextRAttackTime = 0f;
    public Animator animator;


    void Update()
    {
        if(Time.time >= nextRAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetTrigger("Fire");
                nextRAttackTime = Time.time + 8f / attackRate;
                
            }
        }
    }

    void Shoot()
    {
        Instantiate(firePrefab, firePoint.position, firePoint.rotation);
    }
}
