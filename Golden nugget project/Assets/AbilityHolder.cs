using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityHolder : MonoBehaviour
{
    public ActiveAbility currentAbility;
    protected float cooldowntime;
    protected float activeTime;
    protected float DurationTime;
    public bool abilityActivated;
    // number of times you can use the ability before it goes in cooldown
    public int AbilityCharges;
    
    protected enum AbilityState
    {
        ready,
        active,
        cooldown
    }
    protected AbilityState state = AbilityState.ready;

    public float returncooldowntime()
    {
        return cooldowntime;
    }
}
