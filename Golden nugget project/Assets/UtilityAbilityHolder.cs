using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityAbilityHolder : AbilityHolder
{
    public int utilityAbilityCharges =1;

    
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
                    if (utilityAbilityCharges > 0)
                    {
                        currentAbility.Activate();
                        currentAbility.PlaySoundEffect();
                        DurationTime = currentAbility.Duration;

                        utilityAbilityCharges--;
                        
                        abilityActivated = false;
                        state = state = AbilityState.ready;
                    }
                    else
                    {
                         state = AbilityState.cooldown;
                    }
                    

                    break;

                case AbilityState.cooldown:
                    if (cooldowntime > 0)
                    {
                        cooldowntime -= Time.deltaTime;
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

