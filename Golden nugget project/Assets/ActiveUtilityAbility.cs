using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveUtilityAbility : ActiveAbility
{

    private GameObject particleInstance;
    public override void ParticleCreatorAndDeleter(bool yORn)
    {
        if (!particleInstance)
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
        Debug.Log("None");
    }
    public override void SetStateBack()
    {
        
    }
}
