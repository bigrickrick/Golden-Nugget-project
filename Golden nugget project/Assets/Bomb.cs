using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] public GameObject bomb;
    

    public int bombDamage;

    [SerializeField] private ParticleSystem explosionParticles;

    public float explosionRadius;


    public void Explode(Entity entity)
    {
        GameObject explosion = Instantiate(explosionParticles.gameObject, bomb.transform.position, Quaternion.identity);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Entity enemy = collision.gameObject.GetComponent<Entity>();
            
            if (enemy != null)
            {
                Explode(enemy);
            }
        }
    }

}
