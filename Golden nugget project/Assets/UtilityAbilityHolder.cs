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
                    if(abilityActivated == true)
                    {
                        state = AbilityState.active;
                    }
                    

                    break;
                case AbilityState.active:
                    
                    currentAbility.Activate();
                    state = AbilityState.cooldown;


                    break;
                case AbilityState.cooldown:
                    if ( utilityAbilityCharges> 0)
                    {
                        utilityAbilityCharges -= 1;
                        abilityActivated = false;
                        state = AbilityState.ready;
                    }
                    else
                    {
                        if (cooldowntime > 0)
                        {
                            cooldowntime -= Time.deltaTime;
                        }
                        else
                        {
                            abilityActivated = false;
                            utilityAbilityCharges = AbilityCharges;
                            state = AbilityState.ready;

                        }

                    }

                    break;
            }
        }



    }

}

