using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveManager : MonoBehaviour
{
    [SerializeField] private List<PassiveAugments> passiveAugmentslist;
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
                            state = PassiveState.active;
                        }
                        break;
                    case PassiveState.active:
                        if (DurationTime > 0)
                        {
                            passive.ActivatePassive();
                            DurationTime -= Time.deltaTime;
                        }
                        else
                        {
                            state = PassiveState.cooldown;
                        }
                        break;
                    case PassiveState.cooldown:
                        passive.SetToOriginalState();
                        Player.Instance.HasEnemyHasdied(false);
                        break;
                }
            }
           
            
        }
    }
}
