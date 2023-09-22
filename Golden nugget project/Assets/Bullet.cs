using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float life = 3;
    public bool IsplayerBullet;
    public int Bulletdamage;
    
    private void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(IsplayerBullet == true)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {

                Entity enemy = collision.gameObject.GetComponent<Entity>();
                Destroy(gameObject);
                if (enemy != null)
                {
                    enemy.DamageRecieve(Bulletdamage);
                    Debug.Log("enemy has recieve damage");
                }


            }
        }
        else if(IsplayerBullet == false)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Entity player = collision.gameObject.GetComponent<Entity>();
                Destroy(gameObject);
                if (player != null)
                {
                    player.DamageRecieve(Bulletdamage);
                    Debug.Log("Player has recieve damage");
                    Debug.Log("Current hp: " + player.HealthPoints);
                    
                }
            }
        }

        
        
    }
}
