using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityAbilityHolder : AbilityHolder
{
    public int utilityAbilityCharges;
    private void Update()
    {
        
        if (currentAbility != null)
        {
            switch (state)
            {
                case AbilityState.ready:
                    if (abilityActivated)
                    {
                        state = AbilityState.active;
                    }
                    break;

                case AbilityState.active:
                    currentAbility.Activate();
                    state = AbilityState.cooldown;
                    DurationTime = currentAbility.Duration;
                    cooldowntime = currentAbility.cooldown;
                    utilityAbilityCharges--; 
                    break;

                case AbilityState.cooldown:
                    
                    if (cooldowntime  > 0)
                    {
                        cooldowntime -= Time.deltaTime; // Count down the cooldown timer
                    }
                    else
                    {
                        
                        if (utilityAbilityCharges <= 0)
                        {
                            utilityAbilityCharges = AbilityCharges;
                        }
                        abilityActivated = false;
                        state = AbilityState.ready;
                    }
                    break;
            }
        }
    }

}

