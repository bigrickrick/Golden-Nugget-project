using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserDrone : EnemyScript
{

    public override void EnemyAttack()
    {
        foreach (Transform firePoint in BulletSpawnPoint)
        {
            GameObject bul = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
            bul.GetComponent<Enemybullet>().SetBulletDamage(damage);
            Vector3 shootingDirection = (Target.position - firePoint.transform.position).normalized;
            Rigidbody rb = bul.GetComponent<Rigidbody>();
            rb.velocity = shootingDirection * bulletSpeed;
            

        }

    }
    public override void EnemyLookAtTarget()
    {
        transform.LookAt(Target);
    }
    public override void ChaseTarget()
    {
        Vector3 direction = Target.position - transform.position;
        direction.Normalize();


        transform.Translate(direction * gameObject.GetComponent<Entity>().EntitySpeed * Time.deltaTime);
        EnemyLookAtTarget();
    }
}
