using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D spiderBody;

    private Vector3 moveDirection = Vector3.down;

    private string coroutineName = "ChangeMovement";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spiderBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        StartCoroutine(ChangeMovement());
    }

    void Update()
    {
        MoveSpider();
    }

    void MoveSpider()
    {
        transform.Translate(moveDirection * Time.deltaTime * 10);
    }
    IEnumerator ChangeMovement()
    {
        yield return new WaitForSeconds(0.5f);

        if(moveDirection == Vector3.down)
        {
            moveDirection = Vector3.up;
        } else
        {
            moveDirection = Vector3.down;
        }
        StartCoroutine(ChangeMovement());
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
            spiderBody.bodyType = RigidbodyType2D.Dynamic;
            StartCoroutine(SpiderDead());
            StopCoroutine(coroutineName);
        }
    }
}
