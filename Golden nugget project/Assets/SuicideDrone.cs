using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideDrone : EnemyScript
{
    [SerializeField] private List<PlateBombScript> plateBombs;
    public override void ChaseTarget()
    {
        Vector3 direction = Target.position - transform.position;
        direction.Normalize();


        transform.Translate(direction * gameObject.GetComponent<Entity>().EntitySpeed * Time.deltaTime);
        EnemyLookAtTarget();
    }
    public override void EnemyAttack()
    {
        foreach(PlateBombScript plateBomb in plateBombs)
        {
            plateBomb.TriggerExplosion();
        }

        Destroy(gameObject);
    }
    public override void EnemyLookAtTarget()
    {
        transform.LookAt(Target);
    }
    

}
