using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    [SerializeField] private HPcontroller hp;

    private void Update()
    {
        hp.UpdateHP();
        
    }
    private void Start()
    {
        hp.gameObject.SetActive(true);
    }
}
