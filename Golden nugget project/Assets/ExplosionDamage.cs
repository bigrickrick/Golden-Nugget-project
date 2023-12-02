using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    private int bombdamage;
    public AudioClip explosionSound;
    private string Target;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Target))
        {
            
            
            Entity enemy = collision.gameObject.GetComponent<Entity>();
            PlayExplosionSound();
            enemy.DamageRecieve(bombdamage);
            
        }
    }
    public void setbombdamage(int damage)
    {
        bombdamage = damage;
    }
    public void SetTarget(string targettokill)
    {
        Target = targettokill;
    }
    private void Update()
    {
        if (!gameObject.GetComponent<ParticleSystem>().isPlaying)
        {
            
            gameObject.SetActive(false);
            
        }
        
        
    }

    private void PlayExplosionSound()
    {
        if (explosionSound != null)
        {
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.pitch = Random.Range(0.9f, 1.1f); 
            audioSource.volume = 0.25f; 
            audioSource.PlayOneShot(explosionSound);
            Destroy(audioSource, explosionSound.length + 0.1f);
        }
    }

}
