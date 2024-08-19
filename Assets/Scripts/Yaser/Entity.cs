using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntity", menuName = "Entity")]
public class Entity : ScriptableObject
{
    public float speed;
    public float health;
    public float damage;
}
