using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{

    public abstract void shoot();
    public void PLayGunSound()
    {
        if (GunshotSound != null)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = GunshotSound;
            audioSource.Play();
            Destroy(audioSource, GunshotSound.length + 0.1f);
        }
    }

   
    
    public AudioClip GunshotSound;
    
    public bool HasWeapon;
    public float ShootingSpeed;
    public float BaseShootingSpeed;
    public float bulletSpeed;
    public Sprite GunSprite;
    public int GunDamage;


}