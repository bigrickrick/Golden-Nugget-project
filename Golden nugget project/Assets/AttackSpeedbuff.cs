using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "augments/attackSpeedBuff")]

public class AttackSpeedbuff : Augments
{
    public float attackspeedmodifier;
    public override void Apply(Entity target)
    {
        target.attackspeedModifier += attackspeedmodifier;
    }

}
