using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Augments : ScriptableObject
{
    public bool isApplied;
    public abstract void Apply(Entity target);
    private void Awake()
    {
        isApplied = false;
        Debug.Log("isApplied " + isApplied);
    }
    public void MarkAsApplied()
    {
        isApplied = true;
    }
}
