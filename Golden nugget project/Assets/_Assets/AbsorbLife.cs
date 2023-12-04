using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class AbsorbLife : PassiveAugments
{
    public override void ActivatePassive()
    {
        Player.Instance.GetComponent<Entity>().HealthPoints += 10;
    }
}
