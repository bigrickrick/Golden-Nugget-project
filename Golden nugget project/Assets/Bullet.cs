using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{

    public float life = 2;
    
    
    private void Awake()
    {
        Destroy(gameObject, life);
    }

    public abstract void OnCollisionEnter(Collision collision);
}
