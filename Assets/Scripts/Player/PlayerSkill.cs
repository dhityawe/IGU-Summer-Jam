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
        // Same as before
    }

    public void ThrowWeapon(Vector3 throwDirection)
    {
        // Same as before
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
}
