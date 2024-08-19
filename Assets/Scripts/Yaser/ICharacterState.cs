using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterState
{
    public void Enter(CharacterStateManager character);
    public void Execute(CharacterStateManager character);
    public void Exit(CharacterStateManager character);
}
