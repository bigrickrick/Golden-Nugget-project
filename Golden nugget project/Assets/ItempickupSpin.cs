using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItempickupSpin : MonoBehaviour
{
    public float rotationSpeed = 90;

    private void Update()
    {
        
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
