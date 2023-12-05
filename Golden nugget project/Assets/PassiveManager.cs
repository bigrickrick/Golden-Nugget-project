using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveManager : MonoBehaviour
{
    public List<PassiveAugments> passiveAugmentslist;
    float DurationTime;
    float cooldowntime;
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
        if(passiveAugmentslist.Count > 0)
        {
            foreach (PassiveAugments passive in passiveAugmentslist)
            {
                PassiveAugments.PassiveType type = passive.GetPassiveType();
                if (type == PassiveAugments.PassiveType.OnKill)
                {
                    switch (state)
                    {
                        case PassiveState.ready:
                            DurationTime = passive.Duration;
                            if (Player.Instance.EnemyHasdied() == true)
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
                            Player.Instance.HasEnemyHasdied(false);
                            state = PassiveState.ready;
                            break;
                    }
                }
                else if (type == PassiveAugments.PassiveType.OnHit)
                {
                    switch (state)
                    {
                        case PassiveState.ready:
                            DurationTime = passive.Duration;
                            if (Player.Instance.hasHitSomething == true)
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
                            Player.Instance.hasHitSomething = false;
                            state = PassiveState.ready;
                            break;
                    }
                }
                else if (type == PassiveAugments.PassiveType.AlwaysActive)
                {
                    switch (state)
                    {
                        case PassiveState.ready:
                            DurationTime = passive.Duration;
                            cooldowntime = passive.CooldownPassive;

                            state = PassiveState.active;
                            break;
                        case PassiveState.active:

                            if (DurationTime > 0)
                            {
                                Debug.Log("Buff is activated");
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
                            if (cooldowntime > 0)
                            {
                                cooldowntime -= Time.deltaTime;
                            }
                            else
                            {
                                state = PassiveState.ready;
                            }

                            break;
                    }
                }
                else if (type == PassiveAugments.PassiveType.OnAbilityActivate)
                {
                    switch (state)
                    {
                        case PassiveState.ready:
                            DurationTime = passive.Duration;
                            cooldowntime = passive.CooldownPassive;
                            if (Player.Instance.movementAbility.abilityActivated == true || Player.Instance.utilityAbilityHolder.abilityActivated == true)
                            {
                                state = PassiveState.active;
                            }


                            break;
                        case PassiveState.active:

                            if (DurationTime > 0)
                            {
                                Debug.Log("Buff is activated");
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
                            if (cooldowntime > 0)
                            {
                                cooldowntime -= Time.deltaTime;
                            }
                            else
                            {
                                state = PassiveState.ready;
                            }

                            break;
                    }
                }


            }
        }
        
    }
}
