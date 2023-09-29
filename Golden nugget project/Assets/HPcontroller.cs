using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPcontroller : MonoBehaviour
{
    public Slider hpBar;
    
    private float maxHP = Player.Instance.GetComponent<Entity>().HealthPoints; 
    private float currentHP = Player.Instance.GetComponent<Entity>().HealthPoints;  

    void Start()
    {
        
        hpBar.maxValue = maxHP;
        hpBar.value = currentHP;
    }
    private void Update()
    {
        UpdateHP(currentHP);
    }

    public void UpdateHP(float newHP)
    {
        currentHP = Mathf.Clamp(newHP, 0f, maxHP);  
        hpBar.value = currentHP;
        Debug.Log("hp bar updated");
    }
}
