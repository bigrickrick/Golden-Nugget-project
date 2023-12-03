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
