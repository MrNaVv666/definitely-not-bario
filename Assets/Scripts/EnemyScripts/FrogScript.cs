using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    private Rigidbody2D frogBody;
    private Animator animator;
    private Coroutine frogJump;

    private bool jumpLeft = true;
    private int jumpAmount;


    private void Awake()
    {
        animator = GetComponent<Animator>();    
        frogBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        frogJump = StartCoroutine(FrogJump());
    }

    IEnumerator FrogJump()
    {
        yield return new WaitForSeconds(Random.Range(1f, 4f));

        if (jumpLeft)
        {
            animator.Play("FrogWalk");
        }else
        {
            animator.Play("FrogWalkRight");
        }

        frogJump = StartCoroutine(FrogJump());
    }

    void AnimationFinished()
    {
        jumpAmount++;

        if (jumpLeft)
        {
            animator.Play("FrogIdle");
        }
        else
        {
            animator.Play("FrogIdleRight");
        }

        if (jumpAmount == 3)
        {
            jumpAmount = 0;
            jumpLeft = !jumpLeft;

            Vector3 tempScale = transform.localScale;
            tempScale.x *= -1f;
            transform.localScale = tempScale;
        }

        transform.parent.position = transform.position;
    }
}
