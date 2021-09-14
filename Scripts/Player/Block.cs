using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Animator animator;
    public GameObject blockPoint;
    public float blockRate = 2f;
    float nextBlockTime = 0f;


    void Update()
    {
        if (Time.time >= nextBlockTime)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                animator.SetTrigger("Block");
                nextBlockTime = Time.time + 18f / blockRate;
                blockPoint.SetActive(true);
            }
        }
    }

    void DisableBlock()
    {
        blockPoint.SetActive(false);
    }
}
