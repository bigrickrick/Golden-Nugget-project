using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ThrowBomb : ActiveUtilityAbility
{
    [SerializeField] private Bomb bomb;
    public float throwForce;
    [SerializeField] private Transform throwPoint;
    public float liftMultiplier = 1f;
    private Camera mainCamera;

    public void Awake()
    {
        mainCamera = Camera.main;
        
    }
    public override void Activate()
    {

        throwPoint = Player.Instance.transform;
        Ray ray = mainCamera.ScreenPointToRay(Player.Instance.mousePosition.MousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            

            GameObject bombobject = Instantiate(bomb.gameObject, throwPoint.position, Quaternion.identity);
            Rigidbody rb = bombobject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 direction = (Player.Instance.mousePosition.MousePosition - throwPoint.position).normalized;

                rb.AddForce(direction * throwForce, ForceMode.Impulse);
                rb.AddForce(Vector3.up * throwForce * liftMultiplier, ForceMode.Impulse);
            }
        }


    }
}
