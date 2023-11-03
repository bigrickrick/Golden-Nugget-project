using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "augments/Speedbuff")]
public class Speedbuff : Augments
{
    public float SpeedAmount;
    public override void Apply(Entity target)
    {
        target.EntitySpeed = target.EntitySpeed*SpeedAmount;
    }
}
