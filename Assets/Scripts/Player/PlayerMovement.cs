using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Reference to the SpriteRenderer component
    private SpriteRenderer sr;
    private Rigidbody rb;

    // Reference to the CharacterBaseSO scriptable object
    public CharacterBaseSO characterBase;


    void Start()
    {
        // get the sprite renderer component
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        // get the input from the player and use rigidbody to move the player
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // flip the sprite relative to the direction the player is moving
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            GetComponent<Rigidbody>().velocity = movement * characterBase.movementSpeed;
            FlipSprite();
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

    }
    public void FlipSprite()
    {
        // flip the sprite relative to the direction the player is moving
        if (Input.GetAxis("Horizontal") < 0)
        {
            sr.flipX = true;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            sr.flipX = false;
        }
    }
 
}
