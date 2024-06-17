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
        StartCoroutine(disableBullet(5f));
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
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Beetle" || collision.gameObject.tag == "Snail")
        {
            animator.Play("PlayerBullet");
            StartCoroutine(disableBullet(0.7f));
        }
    }
}
