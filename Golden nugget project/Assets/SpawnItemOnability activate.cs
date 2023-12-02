using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class SpawnItemOnabilityactivate : PassiveAugments
{
    [SerializeField] private GameObject Object;
    public override void ActivatePassive()
    {
        GameObject ob = Instantiate(Object, Player.Instance.transform.position, Quaternion.identity);
    }
}
