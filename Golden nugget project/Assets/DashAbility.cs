using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : ActiveMovementAbility
{
    public float dashSpeed;
    public bool isDashing;
    public float OriginalSpeed;
    public override void Activate()
    {
        basecooldown = cooldown;
        if (!isDashing || cooldown !<=0 )
        {
            
            OriginalSpeed = Player.Instance.GetComponent<Entity>().EntitySpeed;
            isDashing = true;
            if (Duration !<= 0)
            {
                Player.Instance.GetComponent<Entity>().EntitySpeed = Player.Instance.GetComponent<Entity>().EntitySpeed * dashSpeed;
            }
            Duration -= Time.deltaTime;
            cooldown = basecooldown;
           
        }
        

    }
    

}
