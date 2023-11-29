using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    public bool ObjectHasBeenPickedUp;
    
    private PickUpItems Object;

    public void PickUpObject()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, Player.Instance.pickuprange);

        foreach (Collider col in colliders)
        {
            if (col.CompareTag("Pickable"))
            {
                if (!ObjectHasBeenPickedUp)
                {
                    ObjectHasBeenPickedUp = true;
                    Object = col.GetComponent<PickUpItems>();

                    
                    Vector3 offset = Player.Instance.transform.forward * 2;
                    Object.transform.position = Player.Instance.transform.position + offset;

                    
                    Object.transform.parent = Player.Instance.transform;
                    break;
                }
            }
        }
    }

    public void ThrowObject()
    {
        ObjectHasBeenPickedUp = false;
        Object.objectThrown = true;
        Debug.Log("object thrown");

        if (Object != null)
        {
            
            Rigidbody rb = Object.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Object.transform.parent = null;
                
                float throwForce = 10f;
                
                rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
            }
            
        }
    }
    
}
