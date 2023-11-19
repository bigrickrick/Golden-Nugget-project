using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveManager : MonoBehaviour
{
    public List<PassiveAugments> passiveAugmentslist;
    float DurationTime;
    enum PassiveState
    {
        ready,
        active,
        cooldown,
    }
    PassiveState state = PassiveState.ready;

    private void Update()
    {
        Debug.Log("has died " + Player.Instance.EnemyHasdied());
        foreach(PassiveAugments passive in passiveAugmentslist)
        {
            PassiveAugments.PassiveType type = passive.GetPassiveType();
            if (type == PassiveAugments.PassiveType.OnKill)
            {
                switch (state)
                {
                    case PassiveState.ready:
                        DurationTime = passive.Duration;
                        if (Player.Instance.EnemyHasdied()== true)
                        {
                            passive.ActivatePassive();
                            state = PassiveState.active;
                        }
                        break;
                    case PassiveState.active:
                        
                        if (DurationTime > 0)
                        {
                            Debug.Log("Buff is activated");
                            DurationTime -= Time.deltaTime;
                        }
                        else
                        {
                            state = PassiveState.cooldown;
                        }
                        break;
                    case PassiveState.cooldown:
                        passive.SetToOriginalState();
                        
                        break;
                }
            }
           
            
        }
    }
}
