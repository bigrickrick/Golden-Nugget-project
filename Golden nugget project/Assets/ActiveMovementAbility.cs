using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveMovementAbility : ActiveAbility
{
    
    
    protected float OriginalSpeed;
    private GameObject particleInstance;


    public override void ParticleCreatorAndDeleter(bool yORn)
    {
        if(!particleInstance)
        {
            particleInstance = Instantiate(particle.gameObject, Player.Instance.PlayerPosition.position, Quaternion.identity);
            particleInstance.transform.parent = Player.Instance.transform;
            particleInstance.GetComponent<ParticleSystem>().Pause();
        }
        
        if (yORn == true)
        {   
            particleInstance.GetComponent<ParticleSystem>().Play();
            Debug.Log("Playing particles!");
        }
        else if (yORn == false)
        {
            particleInstance.GetComponent<ParticleSystem>().Stop();
            particleInstance.GetComponent<ParticleSystem>().Clear();
            Debug.Log("Stopping particles!");
           
        }
    }

    public override void SaveState()
    {
        OriginalSpeed = Player.Instance.GetComponent<Entity>().EntitySpeed;
    }
    public override void SetStateBack()
    {
        Player.Instance.GetComponent<Entity>().EntitySpeed = OriginalSpeed;
    }
   
    

}
