using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{


    public GameObject bullet;
    public Transform firePoint;
    
    float bulletSpeed = 35f;
    private float timeSinceLastShot = 0;

    public override void shoot()
    {



        timeSinceLastShot += Time.deltaTime;
        Debug.Log("TimeSincelastShot " + timeSinceLastShot);
        if (timeSinceLastShot >= ShootingSpeed)
        {
            GameObject bul = Instantiate(bullet, firePoint.position, Quaternion.identity);


            Vector3 shootingDirection = (Player.Instance.mousePosition.MousePosition - firePoint.position).normalized;

            Rigidbody rb = bul.GetComponent<Rigidbody>();


            rb.velocity = shootingDirection * bulletSpeed;
            timeSinceLastShot = 0;

        }
        
    }
}
