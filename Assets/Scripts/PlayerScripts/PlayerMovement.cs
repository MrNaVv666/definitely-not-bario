using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D playerBody;
    private Animator animator;
    private bool isGrounded;
    private float jumpPower = 9f;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        PlayerWalk();
        PlayerJump();
    }

    void PlayerWalk()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (h > 0)
        {
            playerBody.velocity = new Vector2 (speed, playerBody.velocity.y);
            ChangeDirection(1);
        } else if (h < 0)
        {
            playerBody.velocity = new Vector2(-speed, playerBody.velocity.y);
            ChangeDirection(-1);
        } else
        {
            playerBody.velocity= new Vector2(0, playerBody.velocity.y);
        }

        animator.SetInteger("Speed", Mathf.Abs((int)playerBody.velocity.x));
    }

    void ChangeDirection(int direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetBool("Jump", false);
        }
    }

    void PlayerJump()
    {
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                isGrounded = false;
                playerBody.velocity = new Vector2 (playerBody.velocity.x, jumpPower);
                animator.SetBool("Jump", true);
            }          
        }
    }
}
