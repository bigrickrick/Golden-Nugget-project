using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayGunInventory : MonoBehaviour
{
    [SerializeField] private GunInventory gunInventory;
    [SerializeField] private Image image;
    
    
    private void OnWeaponPickup()
    {
        if (gunInventory.gunlist.Count > 0)
        {
            image.gameObject.SetActive(true);
            Debug.Log("ChangeSprite");
            image.sprite = gunInventory.currentGunUsed.GunSprite; 
            
            
            
        }
    }

    private void Update()
    {
        OnWeaponPickup();
    }

}
