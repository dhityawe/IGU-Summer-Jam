using UnityEngine;

public abstract class AttackState : IState
{
    public virtual void Enter(ICharacter character) { }

    public virtual void Execute(ICharacter character)
    {
        character.Attack();
    }

    public virtual void Exit(ICharacter character) { }
}
