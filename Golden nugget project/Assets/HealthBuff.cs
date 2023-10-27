using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "augments/Healthbuff")]
public class HealthBuff : Augments
{
    
    public int amount;
    
    public override void Apply(Entity target)
    {
        if (!isApplied)
        {
            target.GetComponent<Entity>().HealthPoints += amount;
            target.GetComponent<Entity>().maxHealthPoints += amount;
            Debug.Log("HP augmented by " + amount);
            MarkAsApplied();
            
        }
    }
}
