using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    private Rigidbody2D frogBody;
    private Animator animator;
    private Coroutine frogJump;

    private bool animation_Started;
    private bool animation_Finished;
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

    private void LateUpdate()
    {
        if (animation_Finished == true &&  animation_Started == true)
        {
            animation_Started = false;

            transform.parent.position = transform.position;        }
    }

    IEnumerator FrogJump()
    {
        yield return new WaitForSeconds(Random.Range(1f, 4f));

        animation_Started = true;
        animation_Finished = false;

        if (jumpLeft)
        {
            animator.Play("FrogWalk");
        }

        frogJump = StartCoroutine(FrogJump());
    }

    void AnimationFinished()
    {
        animation_Finished = true;

        animator.Play("FrogIdle");

        transform.parent.position = transform.position;
    }
}
