using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float timebetweenAugments = 0;

    [SerializeField] private GameObject augmentUi;
    [SerializeField] private List<WeaponPickUp> weaponlist;
    
    private void Update()
    {
        timebetweenAugments -= Time.deltaTime;
        
        
        if(timebetweenAugments <= 0)
        {
            augmentUi.SetActive(true);
            augmentUi.GetComponent<AugmentManager>().CreateChoice();
            timebetweenAugments = 60;
        }
        
    }
    private void SummonGun()
    {
        WeaponPickUp randomGun;

        randomGun = weaponlist[Random.Range(0, weaponlist.Count)];
        Vector3 initialPosition = new Vector3(0f, 1f, 0f);

        Instantiate(randomGun, initialPosition, Quaternion.identity);
        Debug.Log("gun has been summon");
    }
}
