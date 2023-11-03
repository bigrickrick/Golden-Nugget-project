using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "augments/addGunAugments")]
public class AddGunAugment : Augments
{
    [SerializeField] Gun gun;
    public override void Apply(Entity target)
    {
        Player.Instance.gunInventory.gunlist.Add(gun);
    }
}
