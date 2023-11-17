using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PassiveAugments : ScriptableObject
{
    public float Duration;
    public PassiveType passiveType;
    public enum PassiveType
    {
        OnKill,
        OnHit,
        OnMovementActivate,
        OnUtilityActivate,
        AlwaysActive
    }
    public abstract void ActivatePassive();
    public abstract void SetToOriginalState();
    public PassiveType GetPassiveType()
    {
        return passiveType; 
    }

}
