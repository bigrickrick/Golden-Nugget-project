using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int HealthPoints;
    public GameObject entity;
    public void DamageRecieve(int damage)
    {
        HealthPoints = HealthPoints - damage;
    }
    private void Update()
    {
        die();
    }
    private void die()
    {
        if (HealthPoints <= 0)
        {
            Destroy(entity);
        }
    }

}
