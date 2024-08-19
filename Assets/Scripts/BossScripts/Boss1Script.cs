using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Script : MonoBehaviour
{
    public GameObject stone;
    public Transform attackInstantiate;
    private Animator animator;

    private string coroutinge_name = "StartAttack";
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        StartCoroutine(coroutinge_name);
    }

    void Attack()
    {
        GameObject obj = Instantiate(stone, attackInstantiate.position, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-250f, -600f), 0f));
    }

    void BackToIdle()
    {
        animator.Play("Boss1Idle");
    }

    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(Random.Range(1.5f, 4f));

        animator.Play("BossAttack");
        StartCoroutine(coroutinge_name);
    }
}
