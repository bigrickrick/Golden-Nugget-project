using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    public string ObjectName;
    public bool objectThrown;
    public int ObjectDamaged;

    void OnCollisionEnter(Collision collision)
    {
        if(Player.Instance.objectHolder.ObjectHasBeenPickedUp == true)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {

                Entity enemy = collision.gameObject.GetComponent<Entity>();

                if (enemy != null)
                {
                    enemy.DamageRecieve(ObjectDamaged);
                    Destroy(gameObject);
                    Debug.Log("enemy has recieve damage");
                }
            }
        }
       
    }
}
