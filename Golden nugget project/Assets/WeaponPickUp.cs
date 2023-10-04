using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    [SerializeField] private Gun gunPickup;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Player.Instance.gunInventory.gunlist.Add(gunPickup);
            Destroy(gameObject);
        }
    }
}
