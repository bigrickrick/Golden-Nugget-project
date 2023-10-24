using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBuff : Augments
{
    public int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<Entity>().HealthPoints += amount;
    }
}
