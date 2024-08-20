using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public GameObject itemSlotParent;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (itemSlotParent.transform.childCount > 1 || Input.GetMouseButtonDown(0))
        {
             ItemDrop();
        }

        // if getkeydown w, a, s, d while click mouse button 0 the item will be thrown in the forward direction
        if (Input.GetMouseButtonDown(0) && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
        {
            ThrowWeapon();
        }
    }

    public void ItemDrop()
    {
        // Get the first child of the itemSlotParent
        Transform firstChild = itemSlotParent.transform.GetChild(0);

        // Set the y position to 0.8 and z position to player's z position + 1
        Vector3 newPosition = firstChild.position;
        newPosition.y = 0.8f;
        newPosition.z = transform.position.z + 2;

        firstChild.position = newPosition;

        // Enable the Rigidbody component on the first child
        Rigidbody firstChildRb = firstChild.GetComponent<Rigidbody>();
        if (firstChildRb != null)
        {
            firstChildRb.isKinematic = false;
        }

        // Detach the first child from the itemSlotParent
        firstChild.SetParent(null);
        
    }

    public void ThrowWeapon ()
    {
        // Get the first child of the itemSlotParent
        Transform firstChild = itemSlotParent.transform.GetChild(0);

        // Add force to the first child in the forward direction
        firstChild.GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.Impulse);

        // Enable the Rigidbody component on the first child
        Rigidbody firstChildRb = firstChild.GetComponent<Rigidbody>();
        if (firstChildRb != null)
        {
            firstChildRb.isKinematic = false;
        }

        // Detach the first child from the itemSlotParent
        firstChild.SetParent(null);
    }
}
