using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownUi : MonoBehaviour
{
    public Image cooldownImage;
    public enum abilityType 
    {
        Utility,
        Movement,
    }
    public abilityType type;
    private void Update()
    {
        if(type == abilityType.Utility)
        {
            if(Player.Instance.utilityAbilityHolder.currentAbility != null)
            {
                cooldownImage.fillAmount = Player.Instance.utilityAbilityHolder.returncooldowntime();
            }
           
        }
        else if(type == abilityType.Movement)
        {
            if(Player.Instance.movementAbility.currentAbility != null)
            {
                cooldownImage.fillAmount = Player.Instance.movementAbility.returncooldowntime();
            }
            
        }
    }

}
