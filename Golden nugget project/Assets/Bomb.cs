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
            explosionParticles.GetComponent<ExplosionDamage>().setbombdamage(bombDamage);
            GameObject explosion = Instantiate(explosionParticles.gameObject, transform.position, Quaternion.identity);
            explosion.GetComponent<ParticleSystem>().Play();
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = explosionSound;
            audioSource.Play();


            Destroy(bomb);

            
            hasExploded = true;
        }
    }
}