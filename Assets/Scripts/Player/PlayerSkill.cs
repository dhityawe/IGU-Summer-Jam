using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public GameObject itemSlotParent;
    public GameObject Player;

    [Header("Throw")]
    public float throwForce = 10f;

    [Header("Dash")]
    public float dashForce = 10f;
    public float dashDuration = 0.2f; // How long the dash lasts
    public float invulnerabilityDuration = 0.2f; // How long the player is invulnerable during the dash
    public LayerMask playerLayer; // The player's layer
    public LayerMask enemyLayer;  // The enemy's layer

    private bool isDashing = false;
    private Rigidbody rb;

    // Initialize the Rigidbody component
    void Start()
    {
        rb = Player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (inputDirection.magnitude > 0)
            {
                ThrowWeapon(inputDirection);
            }
            else
            {
                ItemDrop();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            StartCoroutine(Dash());
        }
    }

    public void ItemDrop()
    {
        // Get the first child of the itemSlotParent
        Transform firstChild = itemSlotParent.transform.GetChild(0);

        // Set the y position to 0.8 and z position to player's z position + 2
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

    public void ThrowWeapon(Vector3 throwDirection)
    {
        // Get the first child of the itemSlotParent
        Transform firstChild = itemSlotParent.transform.GetChild(0);

        // Adjust the initial spawn position to be further away from the player
        Vector3 newPosition = firstChild.position;
        newPosition.y = 0.8f;

        // Adjust the z position to be further away based on the throw direction
        if (throwDirection.z < 0) // Throwing backwards (S direction)
        {
            newPosition.z = transform.position.z - 1f;
        }
        else
        {
            newPosition.z = transform.position.z + 1f;
        }

        // Optionally, adjust the x position if necessary for diagonal throws
        newPosition.x += throwDirection.x * 0.5f; // Adjust this multiplier as needed

        firstChild.position = newPosition;

        // Enable the Rigidbody component on the first child
        Rigidbody firstChildRb = firstChild.GetComponent<Rigidbody>();
        if (firstChildRb != null)
        {
            firstChildRb.isKinematic = false;
        }

        // Detach the first child from the itemSlotParent
        firstChild.SetParent(null);

        // Normalize the throw direction to ensure consistent force regardless of direction
        Vector3 normalizedThrowDirection = throwDirection.normalized;

        // Add force to the first child in the desired direction
        firstChildRb.AddForce(normalizedThrowDirection * throwForce, ForceMode.Impulse);
    }

    private IEnumerator Dash()
    {
        isDashing = true;

        Vector3 movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        if (rb != null && movementInput.magnitude > 0)
        {
            // Disable collisions between the player and enemies
            Physics.IgnoreLayerCollision(playerLayer, enemyLayer, true);

            // Apply an initial dash force
            rb.AddForce(movementInput * dashForce, ForceMode.VelocityChange);

            // Wait for the dash duration
            yield return new WaitForSeconds(dashDuration);

            // Gradually reduce speed instead of stopping immediately
            float currentSpeed = rb.velocity.magnitude;
            while (currentSpeed > 0.1f)
            {
                currentSpeed -= Time.deltaTime * dashForce; // Reduce speed smoothly
                rb.velocity = movementInput * currentSpeed;
                yield return null; // Wait for next frame
            }

            // Reset velocity to zero
            rb.velocity = Vector3.zero;

            // Wait for the invulnerability duration (can be the same as dashDuration or longer)
            yield return new WaitForSeconds(invulnerabilityDuration);

            // Re-enable collisions between the player and enemies
            Physics.IgnoreLayerCollision(playerLayer, enemyLayer, false);
        }

        isDashing = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ally"))
        {
            GameObject weapon = itemSlotParent.transform.GetChild(0).gameObject;
            if(weapon != null)
            {
                weapon.transform.SetParent(Princess.instance.gameObject.transform);
                // set position
                weapon.transform.localPosition = new Vector3(0, 7, 0);
            }
        }
    }

}
