using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 5f; // Default lifetime of the bullet
    public CharacterBaseSO characterBase;

    void Start()
    {
        // Destroy the bullet after 'lifetime' seconds
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the bullet collides with a GameObject tagged "Player"
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                // Apply damage to the player and destroy the bullet
                player.TakeDamage(characterBase.attackDamage);
                Destroy(gameObject);
            }
        }
        // Optional: Handle collision with other types of GameObjects
        // else if (other.CompareTag("Ally"))
        // {
        //     Princess princess = other.GetComponent<Princess>();
        //     if (princess != null)
        //     {
        //         princess.TakeDamage(characterBase.attackDamage);
        //         Destroy(gameObject);
        //     }
        // }
    }
}
