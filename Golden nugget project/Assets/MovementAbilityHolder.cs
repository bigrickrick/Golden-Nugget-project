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
    IEnumerator StopParticle()
    {
        yield return new WaitForSeconds(0.15f);
        currentAbility.ParticleCreatorAndDeleter(false);

    }


    private void Update()
    {
        
        switch (state)
        {
            
            case AbilityState.ready:

                
                currentAbility.SaveState();
                DurationTime = currentAbility.Duration;
                if(Player.Instance.MovementAbilistyIsActivated == true)
                {
                    currentAbility.ParticleCreatorAndDeleter(true);
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
                        state = AbilityState.active;
                        activeTime = currentAbility.ActiveTime;
                        DurationTime -= Time.deltaTime;
                    }
                    else
                    {
                        currentAbility.SetStateBack();
                        StartCoroutine(StopParticle());
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
