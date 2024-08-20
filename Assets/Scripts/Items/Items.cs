using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public ItemType itemType;
    private Rigidbody rb;
    public Transform itemSlotTransform;
    
    public enum ItemType
    {
        Sword = 0,
        Bow = 1,
    }

    public void PickupItem(GameObject itemPickedUp)
    {
        // Disable the Collider and Rigidbody of the item
        itemPickedUp.GetComponent<Collider>().enabled = false;
        
        Rigidbody rb = itemPickedUp.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true; // Stops the Rigidbody from being affected by physics
        }

        // Set item properties
        itemPickedUp.GetComponent<Item>().itemType = itemType;
        itemPickedUp.GetComponent<Item>().itemSlotTransform = itemSlotTransform;
        itemPickedUp.GetComponent<Item>().PickupItem();    

        // Set the item's parent & position to the item slot
        itemPickedUp.transform.SetParent(itemSlotTransform);
        itemPickedUp.transform.localPosition = Vector3.zero;

        switch (itemType)
        {
            case ItemType.Sword:
                Debug.Log("Picked up a sword");
                break;
            case ItemType.Bow:
                Debug.Log("Picked up a bow");
                break;
            default:
                break;
        }
    }
}
