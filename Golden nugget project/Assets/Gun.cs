using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{

    public abstract void shoot();
    public void PLayGunSound()
    {

        gunshotSound.Play();
        Debug.Log("Sound gun played");
    }
    
    public void Start()
    {
        gunshotSound = GetComponent<AudioSource>();
    }
    
    public AudioSource gunshotSound;
    
    public bool HasWeapon;
    public float ShootingSpeed;
    public float BaseShootingSpeed;
    public float bulletSpeed;
    public Sprite GunSprite;
    public int GunDamage;


}