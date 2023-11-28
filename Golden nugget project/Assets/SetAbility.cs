using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "augments/Abilities")]
public class SetAbility : Augments
{
    [SerializeField] private string AbilityType;

    [SerializeField] private ActiveAbility ability;
    public override void Apply(Entity target)
    {
        if(AbilityType == "Utility")
        {
            Player.Instance.utilityAbilityHolder.currentAbility = ability;
        }
        else if(AbilityType == "Ultimate")
        {

        }
        else if(AbilityType == "Movement")
        {
            Player.Instance.movementAbility.currentAbility = ability;
        }
    }
}
