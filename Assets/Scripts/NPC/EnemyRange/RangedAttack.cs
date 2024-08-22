using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Collider enemyCollider; // The enemy's collider
    public float bulletSpeed = 20f;
    public float shootInterval = 2f; // Time in seconds between shots
    public float spawnDistance = 1f; // Distance from the enemy's collider to spawn the bullet

    private float timeBtwShots;
    private Transform target;

    public CharacterBaseSO characterBase;

    void Start()
    {
        timeBtwShots = shootInterval;
    }

    void Update()
    {
        if (target != null)
        {
            if (timeBtwShots > 0)
            {
                timeBtwShots -= Time.deltaTime;
            }
            else
            {
                Shoot();
                timeBtwShots = shootInterval; // Reset the timer
            }
        }
    }

    void Shoot()
    {
        if (target == null)
        {
            Debug.LogWarning("No target set for shooting.");
            return;
        }

        // Calculate the spawn position based on the enemy's collider and facing direction
        Vector3 spawnPosition = CalculateSpawnPosition();

        // Instantiate the bullet at the calculated spawn position and rotation
        GameObject bullet = Instantiate(BulletPrefab, spawnPosition, Quaternion.identity);

        // Get the Rigidbody component of the bullet
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            // Calculate direction to the target
            Vector3 direction = (target.position - spawnPosition).normalized;

            // Set the velocity of the bullet
            bulletRb.velocity = direction * bulletSpeed;
        }
        else
        {
            Debug.LogWarning("BulletPrefab does not have a Rigidbody component.");
        }
    }

    Vector3 CalculateSpawnPosition()
    {
        // Get the center of the enemy's collider
        Vector3 colliderCenter = enemyCollider.bounds.center;

        // Calculate the direction the enemy is facing
        Vector3 forwardDirection = transform.forward;

        // Adjust the spawn position based on the forward direction
        // Calculate the spawn position with offset to avoid collider intersection
        Vector3 spawnPosition = colliderCenter + forwardDirection * spawnDistance;

        // Optionally, adjust the position in X and Z to ensure it's outside the collider
        // Depending on the facing direction, you may need to adjust the offset
        Vector3 enemyToTargetDirection = (target.position - colliderCenter).normalized;

        if (Vector3.Dot(forwardDirection, enemyToTargetDirection) > 0)
        {
            // Spawn in front of the enemy
            spawnPosition = colliderCenter + forwardDirection * spawnDistance;
        }
        else
        {
            // Spawn behind the enemy, if needed (optional, based on game design)
            spawnPosition = colliderCenter - forwardDirection * spawnDistance;
        }

        return spawnPosition;
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
