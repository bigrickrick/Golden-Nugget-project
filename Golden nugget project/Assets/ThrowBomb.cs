using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ThrowBomb : ActiveUtilityAbility
{
    [SerializeField] Bomb bomb;
    public float throwSpeed;
    private Transform ThrowPoint;
    public override void Activate()
    {
        ThrowPoint = Player.Instance.gunInventory.currentGunUsed.transform;
        GameObject Bomb = Instantiate(bomb.gameObject, Player.Instance.transform.position, Quaternion.identity);

        Vector3 shootingDirection = (Player.Instance.mousePosition.MousePosition - ThrowPoint.position).normalized;
        shootingDirection.y = 1;
        Debug.Log("shootingdirection "+shootingDirection);
        Rigidbody rb = Bomb.GetComponent<Rigidbody>();


        rb.AddForce(shootingDirection * throwSpeed);


    }
}
