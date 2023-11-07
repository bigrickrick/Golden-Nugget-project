using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAbilityHolder : MonoBehaviour
{
    public ActiveMovementAbility currentmovementAbility;
    float cooldowntime;
    float activeTime;
    float DurationTime;
    
    enum AbilityState
    {
        ready,
        active,
        cooldown
    }
    AbilityState state = AbilityState.ready;

    public void UpdateAbility()
    {
        switch (state)
        {
            case AbilityState.ready:
                currentmovementAbility.SaveOriginalspeed();
                DurationTime = currentmovementAbility.Duration;
                if(DurationTime > 0)
                {
                    currentmovementAbility.Activate();
                    state = AbilityState.active;
                    activeTime = currentmovementAbility.ActiveTime;
                }
                else
                {
                    currentmovementAbility.SetOriginalSpeedback();
                }
                
            break;
            case AbilityState.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.cooldown;
                    cooldowntime = currentmovementAbility.cooldown;
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
