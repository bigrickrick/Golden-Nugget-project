using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHpBar : MonoBehaviour
{
    [SerializeField] private Image hpBar;
    [SerializeField] private TMPro.TextMeshProUGUI hpbartext;
    public BossScript boss;




    private void Update()
    {
        UpdateHpbar();
    }
    private void UpdateHpbar()
    {
        float healthPercentage = (float)boss.GetComponent<Entity>().HealthPoints / (float)boss.GetComponent<Entity>().maxHealthPoints;
        Debug.Log("Health Percentage: " + healthPercentage);
        hpBar.fillAmount = healthPercentage;
        hpbartext.text = boss.GetComponent<Entity>().HealthPoints.ToString();

    }
}
