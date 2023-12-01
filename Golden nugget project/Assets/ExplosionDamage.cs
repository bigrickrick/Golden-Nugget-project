using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    private int bombdamage;
    public AudioClip explosionSound;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("enemy has been hit by explosion");
            setbombdamage(15);
            Entity enemy = collision.gameObject.GetComponent<Entity>();
            PlayExplosionSound();
            enemy.DamageRecieve(bombdamage);
            
        }
    }
    public void setbombdamage(int damage)
    {
        bombdamage = damage;
    }
    private void Update()
    {
        if (!gameObject.GetComponent<ParticleSystem>().isPlaying)
        {
            
            gameObject.SetActive(false);
            
        }
        else if (gameObject.GetComponent<ParticleSystem>().isPlaying)
        {
            
        }
        
    }

    private void PlayExplosionSound()
    {
        if (explosionSound != null)
        {
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.pitch = Random.Range(0.9f, 1.1f); 
            audioSource.volume = 1.0f; 
            audioSource.PlayOneShot(explosionSound);
            Destroy(audioSource, explosionSound.length + 0.1f);
        }
    }

}
