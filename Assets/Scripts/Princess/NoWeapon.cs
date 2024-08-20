using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoWeapon : PrincessState
{
    private float speed = 2f;
    private float radiusDistance = 3f;
    private Rigidbody princessRb;
    private GameObject player;
    public override void Enter(Princess princess)
    {
        princessRb = princess.GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    public override void Execute(Princess princess)
    {
        if(princess.transform.childCount > 0)
        {
            princess.ChangeState(princess.weapon);
        }
        else
        {
            FollowPlayer(princess);
        }
    }

    public override void Exit(Princess princess)
    {
        
    }

    void FollowPlayer(Princess princess)
    {
        float distance = Vector3.Distance(princess.transform.position, player.transform.position);
        if(distance > radiusDistance)
        {
            Vector3 direction = (player.transform.position - princess.transform.position).normalized;

            princess.transform.position += direction * speed * Time.deltaTime;
        }
    }
}
