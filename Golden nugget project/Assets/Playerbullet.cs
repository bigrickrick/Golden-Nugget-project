using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerbullet : Bullet
{
    public override void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {

            Entity enemy = collision.gameObject.GetComponent<Entity>();
            Destroy(gameObject);
            if (enemy != null)
            {
                enemy.DamageRecieve(Player.Instance.gunInventory.currentGunUsed.GunDamage);
                Debug.Log("enemy has recieve damage");
            }
        }
        if (collision.gameObject.CompareTag("Enemy bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
