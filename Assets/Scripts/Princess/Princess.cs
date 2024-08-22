using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess : MonoBehaviour
{
    public static Princess instance;
    private PrincessState currentState;
    public NoWeapon noWeapon = new();
    public Weapon weapon = new();

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentState = noWeapon;
        currentState?.Enter(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState?.Execute(this);
    }

    public void ChangeState(PrincessState newState)
    {
        currentState?.Exit(this);
        currentState = newState;
        currentState?.Enter(this);
    }

    public void MeleeAttack()
    {
        
    }

    public void RangeAttack()
    {

    }
}
