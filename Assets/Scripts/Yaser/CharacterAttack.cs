using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : ICharacterState
{
    
    public void Enter(CharacterStateManager character)
    {
        Debug.Log("Attacking");
    }

    public void Execute(CharacterStateManager character)
    {
        
    }

    public void Exit(CharacterStateManager character)
    {
        Debug.Log("Attacking Finished");
    }
}
