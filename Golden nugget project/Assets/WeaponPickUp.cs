using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    [SerializeField] private Gun gunPickup;
    public bool HasBeenpickUp = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Player.Instance.gunInventory.gunlist.Add(gunPickup);
            
            Destroy(gameObject);
        }
    }
}
