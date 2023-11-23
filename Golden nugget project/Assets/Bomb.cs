using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] public GameObject bomb;
    public string BombAnimation;

    public int bombDamage;

    ParticleSystem explosionParticles;

    public float explosionRadius;


    public void Explode()
    {
        
        GameObject explosion = Instantiate(explosionParticles.gameObject, bomb.transform.position, Quaternion.identity);
        explosion.GetComponent<ParticleSystem>().Play();

       
        Collider[] colliders = Physics.OverlapSphere(bomb.transform.position, explosionRadius);

        foreach (Collider col in colliders)
        {
            if (col.CompareTag("Enemy"))
            {
                col.GetComponent<Entity>().HealthPoints -= bombDamage;
            }
        }

        
        Destroy(bomb);
    }

    
}
