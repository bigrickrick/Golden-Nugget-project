using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform[] firePoints;
    public float bulletSpeed = 45f;
    public float detectionAngle = 360f;
    public float detectionRange = 20f;

    private void Update()
    {
        if (PlayerInshootrange())
        {
            TrapActivate();
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
        foreach (Transform firePoint in firePoints)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);


            Rigidbody rb = bullet.GetComponent<Rigidbody>();


            rb.velocity = firePoint.eulerAngles * bulletSpeed;
        }
    }

    
}
