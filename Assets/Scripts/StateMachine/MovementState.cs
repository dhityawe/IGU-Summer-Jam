using UnityEngine;

public abstract class MovementState : IState
{
    public virtual void Enter(ICharacter character) { }

    public virtual void Execute(ICharacter character)
    {
        character.Move();
    }

    public virtual void Exit(ICharacter character) { }
}
