using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossScript : MonoBehaviour
{
    public int damage;
    protected Transform Target;

    public string targetstring;

    public LayerMask whatisground, whatisplayer;

    public Vector3 walkPoint;
    protected bool walkPointSet;
    public float walkPointRange;
    public bool AlreadyAttacked;
    public float Attackrange;
    
    public float detectionRange;
    public float BaseTimeBeforeTeleportingAttack;
    public float BaseTimeBeforeSummonAllies;
    private float TimeBeforeTeleportingAttack;
    private float TimeBeforeSummonAllies;

    public bool TargetInRangedAttackRange, TeleportingAttackReady, SummonAlliesReady, TargetInSightRange;

    public enum EnemyState
    {
        Patroling,
        ChaseTarget,
        DashAttack,
        RangedAttack,
        TeleportingAttack,
        SummonAllies,

    }
    public EnemyState enemyState = EnemyState.ChaseTarget;
    
    public GameObject bullet;
    public Transform firePoint;

    public float bulletSpeed = 35f;
    public float baseShootingTimer;

    
    [SerializeField] protected Transform[] BulletSpawnPoint;
    private float ShootingTimer;

    private void Start()
    {
        SetTarget(targetstring);
        SetShootingTimer();
    }
    public void SetShootingTimer()
    {
        ShootingTimer = baseShootingTimer / gameObject.GetComponent<Entity>().attackspeedModifier;
    }


    public void SetTarget(string target)
    {
        Target = GameObject.Find(target).transform;
    }

    public void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            GoToWalkPoint();
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }
    private void GoToWalkPoint()
    {
        Vector3 direction = walkPoint - transform.position;
        direction.Normalize();


        transform.Translate(direction * gameObject.GetComponent<Entity>().EntitySpeed * Time.deltaTime);
    }
    public abstract void ChaseTarget();
    public abstract void EnemyAttack();
    public abstract void EnemyLookAtTarget();

    public void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatisground))
        {
            walkPointSet = true;
        }
    }
    public virtual void DashAttack() { }
    public virtual void TeleportingAttack() { }
    public virtual void SummonAllies() { }

    public float dashCooldown = 5.0f; 
    private float dashTimer = 0.0f;
    public float BaseDashDuration;
    protected float DashDuration = 0;
    public bool IsDashing;
    private void Update()
    {
        
        TargetInRangedAttackRange = Physics.CheckSphere(transform.position, Attackrange, whatisplayer);
        TargetInSightRange = Physics.CheckSphere(transform.position, detectionRange, whatisplayer);
        TimeBeforeTeleportingAttack -= Time.deltaTime;
        TimeBeforeSummonAllies -= Time.deltaTime;
        Debug.Log(TimeBeforeTeleportingAttack);
        switch (enemyState)
        {
            case EnemyState.Patroling:
                if (TargetInSightRange)
                {
                    enemyState = EnemyState.ChaseTarget;
                }
                else
                {
                    enemyState = EnemyState.ChaseTarget;
                }
                break;

            case EnemyState.ChaseTarget:
                ChaseTarget();
                if (TimeBeforeTeleportingAttack <= 0)
                {
                    TeleportingAttackReady = true;
                    enemyState = EnemyState.TeleportingAttack;
                }

                if (TimeBeforeSummonAllies <= 0)
                {
                    SummonAlliesReady = true;
                    enemyState = EnemyState.SummonAllies;
                }

                if (!TargetInSightRange)
                {
                    enemyState = EnemyState.Patroling;
                    break;
                }
                else if (TargetInRangedAttackRange)
                {
                    enemyState = EnemyState.RangedAttack;
                }
                
                
                break;

            case EnemyState.RangedAttack:
                if (!TargetInRangedAttackRange)
                {
                    enemyState = EnemyState.ChaseTarget;
                }
                else
                {
                    if (ShootingTimer <= 0)
                    {
                        EnemyAttack();
                        AlreadyAttacked = true;
                        SetShootingTimer();
                    }
                    else
                    {
                        enemyState = EnemyState.ChaseTarget;
                        ShootingTimer -= Time.deltaTime;
                    }
                }
                break;

            case EnemyState.TeleportingAttack:
                if (TeleportingAttackReady)
                {
                    TeleportingAttack();
                    TeleportingAttackReady = false;
                    TimeBeforeTeleportingAttack = BaseTimeBeforeTeleportingAttack;
                }
                else
                {
                    enemyState = EnemyState.ChaseTarget;
                }
                break;

            case EnemyState.SummonAllies:
                if (SummonAlliesReady)
                {
                    SummonAllies();
                    SummonAlliesReady = false;
                    TimeBeforeSummonAllies = BaseTimeBeforeSummonAllies;
                }
                else
                {
                    enemyState = EnemyState.ChaseTarget;
                }
                break;

        }
        if (dashTimer > 0)
        {
            dashTimer -= Time.deltaTime;
        }
        else
        {
            if (!IsDashing)
            {
                DashAttack();
            }
            DashDuration -= Time.deltaTime;
            if(DashDuration <= 0)
            {
                gameObject.GetComponent<Entity>().EntitySpeed = 10;
                IsDashing = false;
                dashTimer = dashCooldown;
                DashDuration = BaseDashDuration;
            }
            
        }
        
    }
    public bool HasDied = false;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, Attackrange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
       
        
    }
}
