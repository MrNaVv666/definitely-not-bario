using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Health : MonoBehaviour
{
    private Animator animator;
    
    private int health = 5;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void DeactivateBoss()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == Tags.BULLET_TAG)
        {
            health--;
            if (health <= 0)
            {
                animator.Play("BossDead");
            }
        }
    }
}
