using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BonusBlock : MonoBehaviour
{
    public Transform BottomCollision;

    private Animator animator;

    public LayerMask playerLayer;

    private Vector3 moveDirection = Vector3.up;
    private Vector3 originPosition;
    private Vector3 animatorPosition;

    private bool animationStarted;
    private bool used;
    void Awake()
    {
        animator = GetComponent<Animator>();
        used = false;
    }

    private void Start()
    {
        originPosition = transform.position;
        animatorPosition = transform.position;
        animatorPosition.y += 0.15f;
    }

    void Update()
    {
        CheckForCollision();
        AnimateUpDown();
    }

    private void CheckForCollision()
    {
        RaycastHit2D hit = Physics2D.Raycast(BottomCollision.position, Vector2.down, 0.1f, playerLayer);
        if (hit && used != true)
        {
            GameObject.Find("Player").GetComponent<ScoreScript>().BonusBlock();
            animator.Play("BonusBlockIdle");
            used = true;
            animationStarted = true;
        }
    }

    private void AnimateUpDown()
    {
        if (animationStarted == true)
        {
            transform.Translate(moveDirection * Time.smoothDeltaTime);

            if(transform.position.y >= animatorPosition.y)
            {
                moveDirection = Vector3.down;
            }else if (transform.position.y <= originPosition.y)
            {
                animationStarted = false;
            }
        }
    }
}
