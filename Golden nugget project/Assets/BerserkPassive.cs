using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class BerserkPassive : PassiveAugments
{
    
    
    private float BerserkAttackSpeedBonus;
    private float BerserkMovementSpeedBonus;
    private float originalattackspeed;
    private float OriginalMovementSpeed;
    public override void ActivatePassive()
    {

        
        originalattackspeed = Player.Instance.GetComponent<Entity>().attackspeedModifier;
        OriginalMovementSpeed = Player.Instance.GetComponent<Entity>().EntitySpeed;
        BerserkAttackSpeedBonus += 0.5f;
        BerserkMovementSpeedBonus += 3f;
        Player.Instance.GetComponent<Entity>().attackspeedModifier += BerserkAttackSpeedBonus;
        Player.Instance.GetComponent<Entity>().EntitySpeed += BerserkMovementSpeedBonus;
        
            
            
        
    }
    public override void SetToOriginalState()
    {
        Player.Instance.GetComponent<Entity>().attackspeedModifier = originalattackspeed;
        Player.Instance.GetComponent<Entity>().EntitySpeed = OriginalMovementSpeed;
        BerserkAttackSpeedBonus = 0;
        BerserkMovementSpeedBonus = 0;
    }


}
