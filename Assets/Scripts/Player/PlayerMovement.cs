using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    Rigidbody2D rb;
    private Vector2 movement;

    //awake to get the rigidbody component
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //fixed update for running physics calculations
    private void FixedUpdate()
    {
        Movement();
    }

    //move the player 
    private void Movement()
    {
        //get the input for the X and Y axis
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //add the movement to the rb velocity
        rb.velocity = movement * moveSpeed;
    }
}
