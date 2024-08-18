using UnityEngine;

public class Enemy : CharacterBase
{
    private Transform target;

    private void Start()
    {
        movementSpeed = 3f; // Same as player speed for consistency
        attackRange = 2f;   // Maintain original attack range
        damage = 5f;        // Maintain original damage

        // Find the player object and set the target
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void Move()
    {
        if (target != null)
        {
            // Calculate direction towards the player
            Vector3 direction = (target.position - transform.position).normalized;

            // Move the enemy towards the player
            transform.Translate(direction * movementSpeed * Time.deltaTime, Space.World);
        }
    }
}
