using UnityEngine;

public abstract class CharacterBase : MonoBehaviour, ICharacter
{
    public float movementSpeed;
    public float attackRange;
    public float damage;

    protected Transform target; // Used for the Enemy to track the Player

    public virtual void Move()
    {
        // Common movement logic can be overridden by subclasses if needed
    }

    public virtual void Attack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);
        foreach (var hitCollider in hitColliders)
        {
            IDamageable target = hitCollider.GetComponent<IDamageable>();
            if (target != null && hitCollider.gameObject != gameObject)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
