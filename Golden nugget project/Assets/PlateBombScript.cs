using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBombScript : MonoBehaviour
{
    public int bombDamage;
    [SerializeField] private ParticleSystem explosionParticles;
    public float explosionRadius;
    public AudioClip explosionSound;

    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            TriggerExplosion();
        }
    }

    public void TriggerExplosion()
    {
        if (explosionParticles != null)
        {
            ExplosionDamage explosionDamage = explosionParticles.GetComponent<ExplosionDamage>();

            if (explosionDamage != null)
            {
                explosionDamage.SetTarget("Player");
                explosionDamage.setbombdamage(bombDamage);
            }
            else
            {
                Debug.LogWarning("ExplosionDamage component not found on explosionParticles.");
                return;
            }

            GameObject explosion = Instantiate(explosionParticles.gameObject, transform.position, Quaternion.identity);
            explosion.GetComponent<ParticleSystem>().Play();

            if (audioSource != null && explosionSound != null)
            {
                audioSource.clip = explosionSound;
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("AudioSource or explosionSound is not set.");
            }

            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("Explosion particles not assigned to the bomb.");
        }
    }
}
