using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHpBarUI : MonoBehaviour
{
    [SerializeField] Image EnemyhpBar;
    [SerializeField] EnemyScript enemy;

    private void Update()
    {
        EnemyhpBar.fillAmount = enemy.GetComponent<Entity>().HealthPoints;
    }
}
