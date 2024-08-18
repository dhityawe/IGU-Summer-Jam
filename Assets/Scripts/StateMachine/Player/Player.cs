using UnityEngine;

public class Player : CharacterBase
{
    
    private void Start()
    {
        movementSpeed = 5f; // Increased speed
        attackRange = 5f;
        damage = 10f;
    }

    public override void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
    }
}

