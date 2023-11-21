using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 2.0f;

    [SerializeField] private Camera Maincamera;
    [SerializeField] private GameObject sphere;
    
    public Vector3 MousePosition;
    public Ray ray;


    private void Update()
    {

        ray = Maincamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            MousePosition = raycastHit.point;
            MousePosition.y = 1f;
            transform.position = MousePosition;
        }
        
    }
}
