using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityAbilityHolder : AbilityHolder
{
    private void Update()
    {
        if (currentAbility != null)
        {
            switch (state)
            {

                case AbilityState.ready:


                    break;
                case AbilityState.active:
                    


                    break;
                case AbilityState.cooldown:

                    
                    break;
            }
        }



    }

}

