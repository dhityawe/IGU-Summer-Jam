using UnityEngine;

[CreateAssetMenu(fileName = "CharacterBaseSO", menuName = "CharacterBaseSO")]
public class CharacterBaseSO : ScriptableObject
{
    [Header("Character Type")]
    public bool isMelee;
    public bool isRanged;

    [Header("Character Base Stats")]
    public float health;
    public float movementSpeed;

    [Header("Character Attack Stats")]
    public float attackDamage;
    public float attackRange;
    public float attackRate;

}
