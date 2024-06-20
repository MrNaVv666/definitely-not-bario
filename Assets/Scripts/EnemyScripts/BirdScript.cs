using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScripts : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D birdBody;
    public GameObject birdStone;

    private Vector3 moveDirection = Vector3.left;
    private Vector3 originPosition;
    private Vector3 movePosition;

    public LayerMask playerLayer;
    
    private bool hasStone;
    private bool canMove;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        birdBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        originPosition = transform.position;
        originPosition.x += 6f;

        movePosition = transform.position;
        movePosition.x -= 6f;

        canMove = true;
        hasStone = true;
    }

    void Update()
    {
        MoveBird();
        DropStone();
    }

    void MoveBird()
    {
        if (canMove)
        {
            transform.Translate(moveDirection * (Time.smoothDeltaTime*3));
            if(transform.position.x >= originPosition.x)
            {
                moveDirection = Vector3.left;
                ChangeDirection();
            } else if (transform.position.x <= movePosition.x)
            {
                moveDirection = Vector3.right;
                ChangeDirection();
            }
        }
    }

    void ChangeDirection()
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x *= -1;
        transform.localScale = tempScale;
    }

    void DropStone()
    {
        if(hasStone)
        {
            if(Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, playerLayer))
            {
                Instantiate(birdStone, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.identity);
                hasStone = false;
                animator.Play("BirdWithoutStone");
            }
        }
    }

    IEnumerator BirdDead()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Tags.BULLET_TAG)
        {
            animator.Play("BirdDead");

            GetComponent<BoxCollider2D>().isTrigger = true;
            birdBody.bodyType = RigidbodyType2D.Dynamic;

            canMove = false;

            StartCoroutine(BirdDead());
        }
    }
}
