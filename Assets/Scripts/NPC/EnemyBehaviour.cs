using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Reference to the CharacterBaseSO scriptable object
    public CharacterBaseSO characterBase;

    // Reference to the player position so it will chase the player
    [HideInInspector] public GameObject player, princess;

    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        princess = GameObject.Find("Princess");
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        float playerTarget = Vector3.Distance(player.transform.position, transform.position);
        float princessTarget = Vector3.Distance(princess.transform.position, transform.position);

        if(playerTarget > princessTarget)
        {
            Vector3 direction = (princess.transform.position - transform.position).normalized;
            transform.position += direction * characterBase.movementSpeed * Time.deltaTime;
        }
        else
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * characterBase.movementSpeed * Time.deltaTime;
        }
    }
}
