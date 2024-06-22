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

    void Update()
    {
        
    }

    IEnumerator FrogJump()
    {
        yield return new WaitForSeconds(Random.Range(1f, 4f));

        if (jumpLeft)
        {
            animator.Play("FrogWalk");
        }

        frogJump = StartCoroutine(FrogJump());
    }

    void AnimationFinished()
    {
        animator.Play("FrogIdle");
    }
}
