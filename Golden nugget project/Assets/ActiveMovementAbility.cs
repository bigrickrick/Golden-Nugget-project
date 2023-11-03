using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveMovementAbility : MonoBehaviour
{
    public float cooldown;
    public float basecooldown;
    public float Duration;

    
    public abstract void Activate();
    
}
