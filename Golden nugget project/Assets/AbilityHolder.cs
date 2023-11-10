using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityHolder : MonoBehaviour
{
    public ActiveAbility currentAbility;
    protected float cooldowntime;
    protected float activeTime;
    protected float DurationTime;


}
