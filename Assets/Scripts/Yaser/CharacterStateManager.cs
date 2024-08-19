using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateManager : MonoBehaviour
{
    // variable character
    [Header("Character Variables")]
    public Entity entity;
    [Space]
    private ICharacterState currentState;
    // state character
    public CharacterMove moveState = new();
    public CharacterAttack attackState = new();
    // Start is called before the first frame update
    void Start()
    {
        currentState = moveState;
        currentState.Enter(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Execute(this);
    }

    public void ChangeState(ICharacterState newState)
    {
        currentState.Exit(this);
        currentState = newState;
        currentState.Enter(this);
    }
}
