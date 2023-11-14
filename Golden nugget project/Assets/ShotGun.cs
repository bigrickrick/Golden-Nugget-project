using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Gun
{
    public GameObject bulletPrefab;     
    public Transform[] firePoints;       
    
    public int pelletsPerShot = 1;
    

   
    public override void shoot()
    {
        for (int i = 0; i < pelletsPerShot; i++)
        {

            Vector3 randomDirection = Quaternion.Euler(0, Random.Range(-10f, 10f), 0) * transform.forward;

            foreach (Transform firePoint in firePoints)
            {

                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);


                Rigidbody rb = bullet.GetComponent<Rigidbody>();


                rb.velocity = randomDirection * bulletSpeed;
            }

        }
        PLayGunSound();


    }
}
