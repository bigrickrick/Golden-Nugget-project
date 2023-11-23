using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionEnemy : EnemyScript
{
    
    public override void ChaseTarget()
    {
        Vector3 direction = Target.position - transform.position;
        direction.Normalize();


        transform.Translate(direction * gameObject.GetComponent<Entity>().EntitySpeed * Time.deltaTime);
        EnemyLookAtTarget();
    }
    public override void EnemyLookAtTarget()
    {
        transform.LookAt(Target.position);
    }
    public override void EnemyAttack()
    {
        
        EnemyLookAtTarget();

        GameObject bul = Instantiate(bullet, firePoint.position, Quaternion.identity);


        Vector3 shootingDirection = (Player.Instance.PlayerPosition.position - firePoint.position).normalized;

        Rigidbody rb = bul.GetComponent<Rigidbody>();


        rb.velocity = shootingDirection * bulletSpeed;
    }
    

    


}
