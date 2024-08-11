using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailScript : MonoBehaviour
{
    public float speed = 2f;
    private bool moveLeft, canMove, stunned;
    private Rigidbody2D snailBody;
    private Animator animator;
    public Transform downCollision, topCollision, LeftCollision, RightCollision;
    private Vector3 leftCollisionPosition, rightCollisionPosition;
    public LayerMask playerLayer, groundLayer;

    private void Awake()
    {
        snailBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        leftCollisionPosition = LeftCollision.localPosition;
        rightCollisionPosition = RightCollision.localPosition;
        print(leftCollisionPosition);
        print(rightCollisionPosition);
    }
    void Start()
    {
        moveLeft = true;
        canMove = true;
        stunned = false;
    }

    void Update()
    {
        if(canMove)
        {
            if (moveLeft)
            {
                snailBody.velocity = new Vector2(-speed, snailBody.velocity.y);
            }
            else
            {
                snailBody.velocity = new Vector2(speed, snailBody.velocity.y);
            }
        }
        CheckCollision();
    }

    void CheckCollision()
    {
        RaycastHit2D leftHit = Physics2D.Raycast(LeftCollision.position, Vector2.left, 0.1f, playerLayer);
        RaycastHit2D rightHit = Physics2D.Raycast(RightCollision.position, Vector2.right, 0.1f, playerLayer);

        Collider2D topHit = Physics2D.OverlapCircle(topCollision.position, 0.25f, playerLayer);

        if (topHit != null)
        {
            if(topHit.gameObject.tag == Tags.PLAYER_TAG)
            {
                if(!stunned)
                {
                    stunned = true;
                    topHit.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(topHit.gameObject.GetComponent<Rigidbody2D>().velocity.x, 12f);
                    canMove = false;
                    snailBody.velocity = new Vector2(0, 0);
                    animator.Play("SnailDead");
                }
            }
        }

        if (leftHit)
        {
            if (leftHit.collider.gameObject.tag == Tags.PLAYER_TAG)
            {
                if (!stunned)
                {
                    print("A MASZ");
                } else
                {
                    snailBody.velocity = new Vector2(50, snailBody.velocity.y);
                }
            }
        }

        if (rightHit)
        {
            if (rightHit.collider.gameObject.tag == Tags.PLAYER_TAG)
            {
                if (!stunned)
                {
                    print("A MASZ");
                }
                else
                {
                    snailBody.velocity = new Vector2(-50, snailBody.velocity.y);
                }
            }
        }

        if (!Physics2D.Raycast(downCollision.position, Vector2.down, 0.1f, groundLayer))
        {
            ChangeDirection();
            print("NI MA");
        }
    }
    void ChangeDirection()
    {
        moveLeft = !moveLeft;
        Vector3 tempScale = transform.localScale;
        if (moveLeft)
        {
            tempScale.x = Mathf.Abs(tempScale.x);
            LeftCollision.localPosition = leftCollisionPosition;
            RightCollision.localPosition = rightCollisionPosition;
         
        }
        else
        {
            tempScale.x = -Mathf.Abs(-tempScale.x);
            LeftCollision.localPosition = rightCollisionPosition;
            RightCollision.localPosition = leftCollisionPosition;
        }
        transform.localScale = tempScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Tags.BULLET_TAG)
        {
            animator.Play("SnailDead");
            canMove = false;
            snailBody.velocity = new Vector2(0, 0);
            stunned = true;
        };
    }
}
