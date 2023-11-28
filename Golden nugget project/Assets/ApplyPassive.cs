using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "augments/Passives")]
public class ApplyPassive : Augments
{
    [SerializeField] private PassiveAugments passive;
    public override void Apply(Entity target)
    {
        Player.Instance.passiveManager.passiveAugmentslist.Add(passive);
    }
}
