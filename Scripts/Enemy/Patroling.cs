using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroling : MonoBehaviour
{
    public float speed = 2;
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public Transform player;
    public Animator animator;
    public float detectDistance;
    public GameObject moveSpot;
    public GameObject moveSpot1;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(-speed, 0);
        if (Vector2.Distance(player.position, rb.position) <= detectDistance)
        {
            sr.flipX = false;
            speed = 0;
            animator.SetBool("IsFollowing", true);
            Destroy(moveSpot);
            Destroy(moveSpot1);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="PatrolSpots")
        {
            if (sr.flipX == false)
            {
                sr.flipX = true;
                speed = -5;
                return;
            }
            else
            {
                sr.flipX = false;
                speed = 5;
            }
        }
    }
    void StopPatrol()
    {
        GetComponent<EnemyDetectAttack>().enabled = true;
        this.enabled = false;
    }

}
