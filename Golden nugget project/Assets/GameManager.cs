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
    [SerializeField] private BossHpBar bossHp;
    
    
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
    
    
    
    private void SummonFinalBoss(BossScript boss)
    {
        
        if (combatDirectory.difficultyScaler >= 10)
        {
            if(FinalBossSummon == false)
            {
                bossHp.gameObject.SetActive(true);
                
                combatDirectory.gameObject.SetActive(false);
                Vector3 bossSpawnPosition = new Vector3(0f, 0f, 0f);
                BossScript bossInstance = Instantiate(boss, bossSpawnPosition, Quaternion.identity);
                bossHp.boss = bossInstance;

                bossInstance.targetstring = "Player";
                FinalBossSummon = true;
                
                
            }

            
        }
    }
}
