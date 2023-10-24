using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Augments : ScriptableObject
{
    public bool isApplied { get; private set; }
    public abstract void Apply(Entity target);
    
    public void MarkAsApplied()
    {
        isApplied = true;
    }
}
