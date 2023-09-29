using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject bulletPrefab;
    public CanonsTrap[] Canons;
    public float bulletSpeed = 45f;
    public float detectionAngle = 360f;
    public float detectionRange = 5f;
    private float ShootingTimer = 1;
    private void Update()
    {
        if (PlayerInshootrange())
        {
            ShootingTimer -= Time.deltaTime;
            if (ShootingTimer <= 0)
            {
                TrapActivate();
                ShootingTimer = 0.5f;
            }
                
        }
    }
    private bool PlayerInshootrange()
    {
        Vector3 directionToPlayer = Player.Instance.PlayerPosition.position - transform.position;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);
        float distanceToPlayer = Vector3.Distance(transform.position, Player.Instance.PlayerPosition.position);


        return angleToPlayer <= detectionAngle * 0.5f && distanceToPlayer <= detectionRange;
    }
    public void TrapActivate()
    {
        foreach (CanonsTrap canons in Canons)
        {
            GameObject bullet = Instantiate(bulletPrefab, canons.firePoint.position, Quaternion.identity);


            Rigidbody rb = bullet.GetComponent<Rigidbody>();


            rb.velocity = canons.transform.eulerAngles * bulletSpeed;
        }
    }

    
}
