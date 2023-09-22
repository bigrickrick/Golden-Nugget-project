using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float detectionAngle = 45f;
    public float detectionRange = 100f;
    public int CreditCost;
    public GameObject bullet;
    public Transform firePoint;
   
    float bulletSpeed = 35f;
    private float ShootingTimer = 1;
    public float movementSpeed = 10f;
    public static EnemyScript Instance { get; private set; }
    [SerializeField] GameObject[] BulletSpawnPoint;
    
    private void Update()
    {
        if (Player.Instance != null)
        {
            
            
            Vector3 directionToPlayer = Player.Instance.PlayerPosition.position - transform.position;

           
            directionToPlayer.Normalize();

           
            transform.Translate(directionToPlayer * movementSpeed * Time.deltaTime);
        }
        EnemyLookAtPlayer();
        if (PlayerInshootrange())
        {
            
            ShootingTimer -= Time.deltaTime;
            if (ShootingTimer <= 0)
            {
                EnemyShoot();
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
    private void EnemyShoot()
    {
        GameObject bul = Instantiate(bullet, firePoint.position, Quaternion.identity);


        Vector3 shootingDirection = (Player.Instance.PlayerPosition.position- firePoint.position).normalized;

        Rigidbody rb = bul.GetComponent<Rigidbody>();


        rb.velocity = shootingDirection * bulletSpeed;
    }
    private void EnemyLookAtPlayer()
    {

        transform.LookAt(Player.Instance.PlayerPosition.position);
        
    }


}
