using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D spiderBody;

    private Vector3 moveDirection = Vector3.down;
    private Coroutine spiderMovement;

    public float moveDistance = 0.5f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spiderBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        spiderMovement = StartCoroutine(ChangeMovement(0.5f));
    }

    void Update()
    {
        MoveSpider();
    }

    void MoveSpider()
    {
        transform.Translate(moveDirection * Time.deltaTime * 10);
    }
    IEnumerator ChangeMovement(float moveDistance)
    {
        yield return new WaitForSeconds(moveDistance);

        if(moveDirection == Vector3.down)
        {
            moveDirection = Vector3.up;
        } else
        {
            moveDirection = Vector3.down;
        }
        spiderMovement = StartCoroutine(ChangeMovement(0.5f));
    }

    IEnumerator SpiderDead()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == Tags.BULLET_TAG)
        {
            animator.Play("SpiderDead");
            moveDirection = Vector3.down;
            spiderBody.bodyType = RigidbodyType2D.Dynamic;
            StartCoroutine(SpiderDead());
            StopCoroutine(spiderMovement);
        }

        if (collision.tag == Tags.PLAYER_TAG)
        {
            collision.GetComponent<PlayerDamage>().DealDamage();
        }
    }
}
