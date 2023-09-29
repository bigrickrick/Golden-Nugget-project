using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPcontroller : MonoBehaviour
{
    public Slider hpBar;

    private Entity playerEntity; // Store the player's Entity component
    private float maxHP;
    private float currentHP;

    private void Start()
    {
        playerEntity = Player.Instance.GetComponent<Entity>();

        if (playerEntity != null)
        {
            maxHP = playerEntity.HealthPoints;
            currentHP = maxHP;
            hpBar.maxValue = maxHP;
            hpBar.value = currentHP;
        }
        else
        {
            Debug.LogError("Player Entity component not found.");
        }
    }

    public void UpdateHP()
    {
        if (playerEntity != null)
        {
            currentHP = playerEntity.HealthPoints;
            hpBar.value = currentHP;
            Debug.Log("hp bar updated");
        }
        else
        {
            Debug.LogError("Player Entity component not found.");
        }
    }
}
