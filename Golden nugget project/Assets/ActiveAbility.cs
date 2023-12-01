using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveAbility : ScriptableObject
{
    public new string name;
    public float cooldown;
    public float Duration;
    public float ActiveTime;
    public ParticleSystem particle;
    public AudioClip AbilitySoundEffect;



    public abstract void ParticleCreatorAndDeleter(bool yOrN);
    public virtual void Activate() { }

    public virtual void SaveState()  { }

    public virtual void SetStateBack() { }

    public virtual void PlaySoundEffect()
    {
        AudioSource audioSource = Player.Instance.GetComponent<AudioSource>();
        audioSource.clip = AbilitySoundEffect;
        audioSource.Play();

        
    }
}
