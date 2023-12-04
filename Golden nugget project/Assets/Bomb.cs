using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private GameObject bomb;
    public int bombDamage;
    [SerializeField] private ParticleSystem explosionParticles;
    public float explosionRadius;
    public AudioClip explosionSound;

    private bool hasExploded = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasExploded && collision.gameObject.CompareTag("Enemy"))
        {
            GameObject explosion = Instantiate(explosionParticles.gameObject, transform.position, Quaternion.identity);
            explosion.GetComponent<ParticleSystem>().Play();

            ExplosionDamage explosionDamage = explosion.GetComponent<ExplosionDamage>();
            if (explosionDamage != null)
            {
                explosionDamage.SetTarget("Enemy");
                explosionDamage.setbombdamage(bombDamage);
            }

            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            if (audioSource != null && explosionSound != null)
            {
                audioSource.clip = explosionSound;
                audioSource.Play();
                Destroy(bomb);
                hasExploded = true;
            }
            else
            {
                Debug.LogWarning("AudioSource or explosionSound is not set.");
            }
        }
    }
}