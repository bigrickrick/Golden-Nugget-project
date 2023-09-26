using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{


    public GameObject bullet;
    public Transform firePoint;
    public Transform direction;
    float bulletSpeed = 35f;
    public override void shoot()
    {
        GameObject bul = Instantiate(bullet, firePoint.position, Quaternion.identity);


        Vector3 shootingDirection = (direction.position - firePoint.position).normalized;

        Rigidbody rb = bul.GetComponent<Rigidbody>();


        rb.velocity = shootingDirection * bulletSpeed;
    }
}
