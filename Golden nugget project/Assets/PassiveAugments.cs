using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PassiveAugments : ScriptableObject
{
    public float Duration;
    public PassiveType passiveType;
    public float CooldownPassive;
    public enum PassiveType
    {
        OnKill,
        OnHit,
        OnAbilityActivate,
        AlwaysActive
    }
    public abstract void ActivatePassive();
    public virtual void SetToOriginalState() { }
    public PassiveType GetPassiveType()
    {
        return passiveType; 
    }

}
