using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkOne : BossScript
{
    public override void ChaseTarget()
    {
        Debug.Log("Boss has acitvated the chase target function");
        Vector3 direction = Target.position - transform.position;
        direction.Normalize();


        transform.Translate(direction * gameObject.GetComponent<Entity>().EntitySpeed * Time.deltaTime);
        EnemyLookAtTarget();
    }
    public ParticleSystem dashParticles; 
    public ParticleSystem teleportParticles;
    public override void EnemyAttack()
    {
        EnemyLookAtTarget();

        GameObject bul = Instantiate(bullet, firePoint.position, Quaternion.identity);
        bul.GetComponent<Enemybullet>().SetBulletDamage(damage);

        Vector3 shootingDirection = (Target.position - firePoint.position).normalized;

        Rigidbody rb = bul.GetComponent<Rigidbody>();


        rb.velocity = shootingDirection * bulletSpeed;
    }
    public override void EnemyLookAtTarget()
    {
        transform.LookAt(Target);
    }
    public int dashSpeed;

    public override void DashAttack()
    {
        gameObject.GetComponent<Entity>().EntitySpeed += dashSpeed;
        IsDashing = true;

        if (dashParticles != null)
        {
            var particleInstance = Instantiate(dashParticles, transform.position, Quaternion.identity);
            particleInstance.transform.parent = transform;
            particleInstance.Play();
        }
    }
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag(targetstring))
        {
            if (IsDashing)
            {
                Entity player = collision.gameObject.GetComponent<Entity>();
                if (player != null)
                {
                    player.DamageRecieve(damage);
                    
                }
            }
        }
        
    }
    public int BaseTeleportationstack;
    private int teleportationstack;
    public override void TeleportingAttack()
    {
        StartCoroutine(TeleportWithDelay());
    }

    IEnumerator TeleportWithDelay()
    {
        float teleportRange = 15f;

        for (int i = 0; i < BaseTeleportationstack; i++)
        {
            if (teleportationstack != BaseTeleportationstack)
            {
                float randomX = Random.Range(Target.position.x - teleportRange, Target.position.x + teleportRange);
                float randomZ = Random.Range(Target.position.z - teleportRange, Target.position.z + teleportRange);
                Vector3 randomPosition = new Vector3(randomX, transform.position.y, randomZ);

                if (teleportParticles != null)
                {
                    var particleInstance = Instantiate(teleportParticles, transform.position, Quaternion.identity);
                    particleInstance.transform.parent = transform;
                    particleInstance.Play();
                    Destroy(particleInstance.gameObject, particleInstance.main.duration);
                }

                yield return new WaitForSeconds(0.5f);

                transform.position = randomPosition;

                EnemyAttack();
            }
        }
    }
    public GameObject allyPrefab;
    public int maxAlliesToSummon = 3;
    public float maxSummonRadius = 10f;

    public override void SummonAllies()
    {
        for (int i = 0; i < maxAlliesToSummon; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition(); 
            Quaternion spawnRotation = Quaternion.identity; 

            Instantiate(allyPrefab, spawnPosition, spawnRotation);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        
        Vector2 randomCircle = Random.insideUnitCircle.normalized * maxSummonRadius;

        Vector3 bossPosition = transform.position;
        Vector3 spawnPosition = bossPosition + new Vector3(randomCircle.x, 0f, randomCircle.y);

        return spawnPosition;
    }


}
