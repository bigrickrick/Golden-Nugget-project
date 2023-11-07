using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DashAbility : ActiveMovementAbility
{
    public float DashSpeed;
    
    public override void Activate()
    {
        Player.Instance.GetComponent<Entity>().EntitySpeed = Player.Instance.GetComponent<Entity>().EntitySpeed * DashSpeed;

        Debug.Log("dash duration " + Duration);

    }

}
