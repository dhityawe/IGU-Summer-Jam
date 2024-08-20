using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PrincessState
{
    public abstract void Enter(Princess princess);
    public abstract void Execute(Princess princess);
    public abstract void Exit(Princess princess);
}
