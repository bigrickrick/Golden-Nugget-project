using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int HealthPoints;
    public int maxHealthPoints;
    public GameObject entity;
    public float EntitySpeed;
    public float attackspeedModifier;
    
    public void DamageRecieve(int damage)
    {
        HealthPoints = HealthPoints - damage;
    }
    private void Update()
    {
        die();
        
    }
    private void Start()
    {
        maxHealthPoints = HealthPoints;
    }
    private void die()
    {
        if (HealthPoints <= 0)
        {
            Destroy(entity);
        }
    }

}
