using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveMovementAbility : ScriptableObject
{
    
    public new string name;
    public float cooldown;
    public float Duration;
    public float ActiveTime;
    protected float OriginalSpeed;

    

    
    public virtual void Activate() { }
    
    public void SaveOriginalspeed()
    {
        OriginalSpeed = Player.Instance.GetComponent<Entity>().EntitySpeed;
    }
    public void SetOriginalSpeedback()
    {
        Player.Instance.GetComponent<Entity>().EntitySpeed = OriginalSpeed;
    }
    

}
