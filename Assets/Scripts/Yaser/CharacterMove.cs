using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : ICharacterState
{
    public void Enter(CharacterStateManager character)
    {
        Debug.Log("Jumping");
    }

    public void Execute(CharacterStateManager character)
    {
        Move(character);
    }

    public void Move(CharacterStateManager character)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        character.transform.Translate(movement * character.entity.speed * Time.deltaTime, Space.World);
    }

    public void Exit(CharacterStateManager character)
    {
        Debug.Log("Jumping Finished");
    }
}
