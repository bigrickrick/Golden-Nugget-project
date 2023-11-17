using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyScript : MonoBehaviour
{
    public float detectionAngle = 45f;
    public float detectionRange = 100f;
    public int CreditCost;
    public GameObject bullet;
    public Transform firePoint;
    
    public float bulletSpeed = 35f;
    public float baseShootingTimer;
    
    public static EnemyScript Instance { get; private set; }
    [SerializeField] GameObject[] BulletSpawnPoint;
    public float ShootingTimer;
    private void Start()
    {
        ShootingTimer = baseShootingTimer / gameObject.GetComponent<Entity>().attackspeedModifier;
        
    }
    
    public abstract void Move();
    public abstract bool PlayerInshootrange();
    public abstract void EnemyShoot();
    public abstract void EnemyLookAtPlayer();

    private void Update()
    {
        if (gameObject != null)
        {
            if (gameObject.GetComponent<Entity>().HealthPoints <= 0)
            {
                Player.Instance.HasEnemyHasdied(true);

            }
        }
       
    }


}
