using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class LifeStealPassive : PassiveAugments
{
    public override void SetToOriginalState()
    {
        Debug.Log("null");
    }
    public override void ActivatePassive()
    {
        Player.Instance.GetComponent<Entity>().HealthPoints += 1;
    }
}
