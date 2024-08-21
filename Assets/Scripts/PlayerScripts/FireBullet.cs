using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    private float speed = 10f;
    private Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(disableBullet(1.5f));
    }

    void Update()
    {
        Move();
    }

    public float Speed { get { return speed; } set { speed = value; } }

    private void Move()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }

    IEnumerator disableBullet(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tags.SNAIL_TAG || collision.gameObject.tag == Tags.BEETLE_TAG || collision.gameObject.tag == Tags.BIRD_TAG || collision.gameObject.tag == Tags.SPIDER_TAG || collision.gameObject.tag == Tags.BOSS_TAG)
        {
            speed = 0;
            animator.Play("PlayerBullet");
            StartCoroutine(disableBullet(0.25f));
        }
    }
}
