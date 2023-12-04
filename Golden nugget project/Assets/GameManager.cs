using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    private float timebetweenAugments = 0;

    [SerializeField] private GameObject augmentUi;
    [SerializeField] private List<WeaponPickUp> weaponlist;
    public bool augmentOut = true;

    private void Update()
    {
        timebetweenAugments -= Time.deltaTime;

        if (timebetweenAugments <= 0 && augmentUi != null)
        {
            augmentUi.SetActive(true);
            

            
            augmentUi.GetComponent<AugmentManager>()?.CreateChoice();

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
