using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterBaseSO characterBase;
    public void TakeDamage(float damage)
    {
        characterBase.TakeDamage(damage);
        Debug.Log("Player health: " + characterBase.health);
        // Additional logic for when the player is damaged
    }
}
