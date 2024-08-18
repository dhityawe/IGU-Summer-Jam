using UnityEngine;

public class PlayerMovementState : MovementState
{
    public override void Enter(ICharacter character)
    {
        // Additional player-specific enter logic can be added here
    }

    public override void Execute(ICharacter character)
    {
        base.Execute(character);
        // Additional player-specific execute logic can be added here
    }
}
