using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public bool isInRange;
    public LayerMask playerLayer;
    public CharacterBaseSO characterBase;

    [HideInInspector] public GameObject player, princess;
    private RangedAttack rangedAttack;

    void Start()
    {
        player = GameObject.Find("Player");
        princess = GameObject.Find("Princess");
        rangedAttack = GetComponent<RangedAttack>(); // Get the RangedAttack component
    }

    void Update()
    {
        FollowTarget();
        IsPlayerInRange();
    }

    void FollowTarget()
    {
        Transform target = player.transform;
        float playerTarget = Vector3.Distance(player.transform.position, transform.position);
        float princessTarget = Vector3.Distance(princess.transform.position, transform.position);

        if (playerTarget > princessTarget)
        {
            target = princess.transform;
        }
        else
        {
            target = player.transform;
        }

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * characterBase.movementSpeed * Time.deltaTime;

        // Set the target for ranged attack
        if (rangedAttack != null)
        {
            rangedAttack.SetTarget(target);
        }
    }

    void IsPlayerInRange()
    {
        // Get all colliders within the detection radius
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, characterBase.attackRange, playerLayer);

        bool playerInRange = false;
        Transform target = null;

        foreach (var collider in hitColliders)
        {
            if (collider.CompareTag("Player"))
            {
                playerInRange = true;
                target = collider.transform;
                break; // Exit the loop after finding the player
            }
        }

        // Set the target to shoot at
        if (playerInRange)
        {
            if (rangedAttack != null && target != null)
            {
                rangedAttack.SetTarget(target);
                Debug.Log("Player detected within radius! Shooting.");
            }
        }
        else
        {
            // Optionally, you can reset the target if not in range
            if (rangedAttack != null)
            {
                rangedAttack.SetTarget(null);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, characterBase.attackRange);
    }
}
