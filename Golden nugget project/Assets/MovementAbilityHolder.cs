using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAbilityHolder : AbilityHolder
{



    
    IEnumerator StopParticle()
    {
        yield return new WaitForSeconds(0.15f);
        currentAbility.ParticleCreatorAndDeleter(false);

    }
    public int MovementAbilityCharges;

    private void Update()
    {
        
        if (currentAbility != null)
        {
            switch (state)
            {

                case AbilityState.ready:

                    
                    currentAbility.SaveState();
                    DurationTime = currentAbility.Duration;
                    if (abilityActivated == true)
                    {
                        currentAbility.ParticleCreatorAndDeleter(true);
                        Player.Instance.PushForce += 30;

                        state = AbilityState.active;
                        activeTime = currentAbility.ActiveTime;
                    }

                    break;
                case AbilityState.active:
                    if (activeTime > 0)
                    {
                        activeTime -= Time.deltaTime;
                    }
                    else
                    {
                        if (MovementAbilityCharges>0)
                        {
                            if (DurationTime > 0)
                            {

                                currentAbility.Activate();
                                currentAbility.PlaySoundEffect();

                                activeTime = currentAbility.ActiveTime;
                                DurationTime -= Time.deltaTime;
                                abilityActivated = false;
                                MovementAbilityCharges -= 1;
                                state = AbilityState.ready;
                            }
                            else
                            {
                                Player.Instance.PushForce -= 30;
                                
                                currentAbility.SetStateBack();
                                StartCoroutine(StopParticle());
                                

                            }
                        }
                        else
                        {
                            cooldowntime = currentAbility.cooldown;
                            state = AbilityState.cooldown;
                        }
                       
                        
                    }


                    break;
                case AbilityState.cooldown:


                    if (cooldowntime > 0)
                    {
                        cooldowntime -= Time.deltaTime;
                    }
                    else
                    {
                        MovementAbilityCharges = AbilityCharges;
                        abilityActivated = false;
                        state = AbilityState.ready;

                    }

                    break;
            }
        }
       
        

    }
    
}
