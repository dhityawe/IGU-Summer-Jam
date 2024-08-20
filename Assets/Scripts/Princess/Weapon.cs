using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : PrincessState
{
    public override void Enter(Princess princess)
    {
        Debug.Log("State Weapon Masuk");
    }

    public override void Execute(Princess princess)
    {
        // melakukan serangan melingkar 360 derajat untuk melee
        // kalau batu serangan langsung ngincer ke musuh
    }

    public override void Exit(Princess princess)
    {
        
    }
}
