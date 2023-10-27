using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float timebetweenAugments = 0;
    [SerializeField] private GameObject augmentUi;
    private void Update()
    {
        timebetweenAugments -= Time.deltaTime;
        if(timebetweenAugments <= 0)
        {
            augmentUi.SetActive(true);
            timebetweenAugments = 100;
        }
    }

}
