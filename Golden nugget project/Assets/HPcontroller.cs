using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPcontroller : MonoBehaviour
{
    public Slider hpBar;
    
    private float maxHP; 
    private float currentHP = Player.Instance.GetComponent<Entity>().HealthPoints;
   
    void Start()
    {
        maxHP = Player.Instance.GetComponent<Entity>().HealthPoints;
        hpBar.maxValue = maxHP;
        hpBar.value = currentHP;
    }

    public void UpdateHP()
    {
        
        currentHP = Player.Instance.GetComponent<Entity>().HealthPoints;
        Debug.Log(currentHP);
        hpBar.value = currentHP;
        Debug.Log("hp bar updated");
    }
}
