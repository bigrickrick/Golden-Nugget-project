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
    public int MovementAbilityCharges = 1;

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
                                
                            }
                            else
                            {
                                abilityActivated = false;

                                
                                Player.Instance.PushForce -= 30;
                                MovementAbilityCharges -= 1;
                                currentAbility.SetStateBack();
                                StartCoroutine(StopParticle());
                                state = AbilityState.ready;


                            }
                        }
                        else
                        {
                            Player.Instance.PushForce -= 30;

                            currentAbility.SetStateBack();
                            StartCoroutine(StopParticle());
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
            if (DurationTime <= 0)
            {
                Player.Instance.PushForce -= 30;

                currentAbility.SetStateBack();
                StartCoroutine(StopParticle());
            }
        }
       
        
        
    }
    
}
