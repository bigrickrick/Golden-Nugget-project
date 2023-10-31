using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{

    public abstract void shoot();
    public bool HasWeapon;
    public float ShootingSpeed;
    public float BaseShootingSpeed;
    public float bulletSpeed;
    public Sprite GunSprite;
    public int GunDamage;


}