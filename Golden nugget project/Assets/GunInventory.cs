using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInventory : MonoBehaviour
{
    public List<Gun> gunlist = new List<Gun>();
    public Gun currentGunUsed;
    private int gunNumer = 0;
    public bool HasGunInHand;
    
    private void Update()
    {
        if(gunlist.Count > 0)
        {
            if (!HasGunInHand)
            {
                MakeGunAppearInPlayerHand();
                HasGunInHand = true;
            }
            
        }
    }

    public void WeaponSwitch(int number)
    {
        gunNumer += number;

        HasGunInHand = false;
        if (gunNumer >= gunlist.Count)
        {
            gunNumer = 0;
        }
        else if (gunNumer < 0)
        {
            gunNumer = gunlist.Count - 1;
        }
        
    }

    private void MakeGunAppearInPlayerHand()
    {
        if (gunlist != null && gunlist.Count > 0)
        {
            if (currentGunUsed != null)
            {

                currentGunUsed.gameObject.SetActive(false);
                
                currentGunUsed.HasWeapon = false;
                Destroy(currentGunUsed.gameObject);
            }

            currentGunUsed = gunlist[gunNumer];

            if (currentGunUsed != null)
            {
                currentGunUsed.gameObject.SetActive(true);
                currentGunUsed.HasWeapon = true;
                currentGunUsed = Instantiate(gunlist[gunNumer]);
                currentGunUsed.transform.SetParent(transform);
                currentGunUsed.transform.localPosition = Vector3.zero;
                currentGunUsed.transform.localRotation = Quaternion.identity;
            }
        }
        else
        {
            
            Debug.LogError("gunlist is null or empty.");
        }
    }
}




