using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class darkOneBullet : Bullet
{
    private int damage;
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Entity player = collision.gameObject.GetComponent<Entity>();

            if (player != null)
            {
                player.DamageRecieve(damage);
                Debug.Log("Player has recieve damage");
                Debug.Log("Current hp: " + player.HealthPoints);

            }
            Destroy(gameObject);
        }

    }
    public void SetBulletDamage(int EnemyDamage)
    {
        damage = EnemyDamage*2;
    }
}
