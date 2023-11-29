using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    private int bombdamage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("enemy has been hit by explosion");
            setbombdamage(15);
            Entity enemy = collision.gameObject.GetComponent<Entity>();
            enemy.DamageRecieve(bombdamage);
        }
    }
    public void setbombdamage(int damage)
    {
        bombdamage = damage;
    }

}
