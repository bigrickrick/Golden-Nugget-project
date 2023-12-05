using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    private float timebetweenAugments = 0;
    [SerializeField] private CombatDirectory combatDirectory;
    [SerializeField] private GameObject augmentUi;
    [SerializeField] private List<WeaponPickUp> weaponlist;
    private bool FinalBossSummon = false;
    public bool augmentOut = true;
    [SerializeField] private BossScript boss;

    private void Update()
    {
        timebetweenAugments -= Time.deltaTime;

        if (timebetweenAugments <= 0 && augmentUi != null)
        {
            augmentUi.SetActive(true);
            

            
            augmentUi.GetComponent<AugmentManager>()?.CreateChoice();

            timebetweenAugments = 30;
        }
        SummonFinalBoss(boss);
       
    }
    private void SummonGun()
    {
        WeaponPickUp randomGun;

        randomGun = weaponlist[Random.Range(0, weaponlist.Count)];
        Vector3 initialPosition = new Vector3(0f, 1f, 0f);

        Instantiate(randomGun, initialPosition, Quaternion.identity);
        Debug.Log("gun has been summon");
    }
    private void SummonFinalBoss(BossScript boss)
    {
        if(combatDirectory.difficultyScaler >= 10)
        {
            if(FinalBossSummon == false)
            {
                combatDirectory.gameObject.SetActive(false);
                Vector3 bossSpawnPosition = new Vector3(0f, 0f, 0f); 
                BossScript bossInstance = Instantiate(boss, bossSpawnPosition, Quaternion.identity);


                bossInstance.targetstring = "Player";
                FinalBossSummon = true;
                Debug.Log("Boss has been summoned");
            }
            

        }
    }
}
