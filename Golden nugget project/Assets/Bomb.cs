using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private GameObject bomb;
    public int bombDamage;
    [SerializeField] private ParticleSystem explosionParticles;
    public float explosionRadius;

    private bool hasExploded = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasExploded)
        {
            if (!collision.gameObject.CompareTag("Player"))
            {
                Explode();
                hasExploded = true;
            }
            
        }
    }

    public void Explode()
    {
        GameObject explosion = Instantiate(explosionParticles.gameObject, transform.position, Quaternion.identity);
        explosion.GetComponent<ParticleSystem>().Play();

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hit in colliders)
        {
            if (hit.CompareTag("Enemy"))
            {
                Entity enemy = hit.GetComponent<Entity>();
                if (enemy != null)
                {
                    enemy.DamageRecieve(bombDamage);
                }
            }
        }

        Destroy(bomb);
    }
}
