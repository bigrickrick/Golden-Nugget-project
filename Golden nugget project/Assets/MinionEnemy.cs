using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionEnemy : EnemyScript
{
    public override void Move()
    {
        if (Player.Instance != null)
        {


            Vector3 directionToPlayer = Player.Instance.PlayerPosition.position - transform.position;


            directionToPlayer.Normalize();


            transform.Translate(directionToPlayer * gameObject.GetComponent<Entity>().EntitySpeed * Time.deltaTime);
            EnemyLookAtPlayer();
        }
    }
    public override void EnemyLookAtPlayer()
    {
        transform.LookAt(Player.Instance.PlayerPosition.position);
    }
    public override void EnemyShoot()
    {
        GameObject bul = Instantiate(bullet, firePoint.position, Quaternion.identity);


        Vector3 shootingDirection = (Player.Instance.PlayerPosition.position - firePoint.position).normalized;

        Rigidbody rb = bul.GetComponent<Rigidbody>();


        rb.velocity = shootingDirection * bulletSpeed;
    }
    public override bool PlayerInshootrange()
    {
        Vector3 directionToPlayer = Player.Instance.PlayerPosition.position - transform.position;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);
        float distanceToPlayer = Vector3.Distance(transform.position, Player.Instance.PlayerPosition.position);


        return angleToPlayer <= detectionAngle * 0.5f && distanceToPlayer <= detectionRange;
    }

    private void Update()
    {

        Move();
        
        if (PlayerInshootrange())
        {

            ShootingTimer -= Time.deltaTime;
            if (ShootingTimer <= 0)
            {
                EnemyShoot();
                ShootingTimer = baseShootingTimer / gameObject.GetComponent<Entity>().attackspeedModifier;
            }
            
        }


    }


}
