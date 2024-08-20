using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
        Sword,
        Bow
}


//singleton to the
public class Items : MonoBehaviour
{
    public ItemType itemType;
    public GameObject itemSlotParent;

    public float pickUpCooldown = 0.3f;
    
    

    private void OnCollisionEnter(Collision collision)
    {
        
        // Check if the collided object has the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            // Call the ItemCollide method
            ItemCollidePlayer();

            Debug.Log("Item Collided");
        }

        else if (collision.gameObject.CompareTag("Ally"))
        {
            // Call the ItemDropped method
            ItemCollideAlly();

            Debug.Log("Item Equipped by Ally");
        }
    }

    public void ItemCollidePlayer()
    {
        // Get the Rigidbody component
        Rigidbody rb = GetComponent<Rigidbody>();

        // Set this item as a child of the itemSlotParent
        transform.SetParent(itemSlotParent.transform);

        // Reset the local position to (0, 0, 0)
        transform.localPosition = Vector3.zero;

        if (rb != null)
        {
            // Disable the Rigidbody component
            rb.isKinematic = true;
        }

        // Check if the itemSlotParent has more than 1 child
        if (itemSlotParent.transform.childCount > 1)
        {
            ItemDropped();
        }
    }

    public void ItemCollideAlly()
    {
        //* Ally Equip Item on collision here
    }

    public void ItemDropped()
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
}
