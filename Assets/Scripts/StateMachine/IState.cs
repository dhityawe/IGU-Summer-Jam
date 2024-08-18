using UnityEngine;
public interface IState
{
    void Enter(ICharacter character);
    void Execute(ICharacter character);
    void Exit(ICharacter character);
}
