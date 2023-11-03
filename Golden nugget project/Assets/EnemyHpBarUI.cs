using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHpBarUI : MonoBehaviour
{
    [SerializeField] Image EnemyhpBar;
    [SerializeField] Entity enemy;
    
    
    private void Update()
    {
        
        UpdateHpbar();
        
    }
    private void UpdateHpbar()
    {
        if (enemy != null && EnemyhpBar != null)
        {
            float healthPercentage = (float)enemy.HealthPoints / (float)enemy.maxHealthPoints;
            Debug.Log("Health Percentage: " + healthPercentage); 
            EnemyhpBar.fillAmount = healthPercentage;
            Debug.Log(EnemyhpBar.fillAmount);
        }

    }
}
