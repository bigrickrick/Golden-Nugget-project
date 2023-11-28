using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Teleport : ActiveMovementAbility
{
    public override void Activate()
    {
       Player.Instance.transform.position = Player.Instance.mousePosition.MousePosition;
    }
}
