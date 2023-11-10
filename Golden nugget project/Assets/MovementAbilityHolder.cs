using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAbilityHolder : AbilityHolder
{
    
    
    enum AbilityState
    {
        ready,
        active,
        cooldown
    }
    AbilityState state = AbilityState.ready;
    
    
    private void Update()
    {
        
        switch (state)
        {
            
            case AbilityState.ready:

                
                currentAbility.SaveState();
                DurationTime = currentAbility.Duration;
                if(Player.Instance.MovementAbilistyIsActivated == true)
                {
                    state = AbilityState.active;
                    activeTime = currentAbility.ActiveTime;
                }
                                
            break;
            case AbilityState.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    if (DurationTime > 0)
                    {
                        currentAbility.Activate();
                        currentAbility.ParticleCreatorAndDeleter(true);
                        state = AbilityState.active;
                        activeTime = currentAbility.ActiveTime;
                        DurationTime -= Time.deltaTime;
                    }
                    else
                    {
                        currentAbility.SetStateBack();
                        currentAbility.ParticleCreatorAndDeleter(false);
                        cooldowntime = currentAbility.cooldown;
                        state = AbilityState.cooldown;

                    }
                }
               
                
            break;
            case AbilityState.cooldown:
                if (cooldowntime > 0)
                {
                    cooldowntime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;
                    
                }
            break;
        }
        

    }
    
}
