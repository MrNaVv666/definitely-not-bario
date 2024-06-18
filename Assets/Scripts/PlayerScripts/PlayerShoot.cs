using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject fireBullet;

    void Update()
    {
        ShootBullet();
    }

    void ShootBullet()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameObject bullet = Instantiate(fireBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<fireBullet>().Speed *= transform.localScale.x;
        }    
    }
}
