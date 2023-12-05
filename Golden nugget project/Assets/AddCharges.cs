using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "augments/AddCharges")]
public class AddCharges : Augments
{
    public enum WhichAbility 
    {
        Utiliy,
        Movement
    }
    public WhichAbility ability;
    public override void Apply(Entity target)
    {
        if(ability == WhichAbility.Utiliy)
        {
            Player.Instance.movementAbility.AbilityCharges += Player.Instance.movementAbility.AbilityCharges+1;
        }
        else if (ability == WhichAbility.Utiliy)
        {
            Player.Instance.utilityAbilityHolder.AbilityCharges += Player.Instance.utilityAbilityHolder.AbilityCharges + 1;
        }
    }
}
