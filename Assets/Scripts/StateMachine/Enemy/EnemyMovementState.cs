using UnityEngine;

public class EnemyMovementState : MovementState
{
    public override void Enter(ICharacter character)
    {
        // Additional enemy-specific enter logic can be added here
    }

    public override void Execute(ICharacter character)
    {
        base.Execute(character);
        // Additional enemy-specific execute logic can be added here
    }
}
