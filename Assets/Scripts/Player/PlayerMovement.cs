using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //player movement
    public float moveSpeed = 10f;
    Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 joystickMovement;
    public Joystick joystick;

    //screen Boundaries
    public Camera mainCamera;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    //awake to get the rigidbody component
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        //get the screen size in relation to the world
        //returns an (X,Y) value half the screen size, these values are negative
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

        //get the object width so that the whole object stays within the boundaries 
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    //late update is called after the movement function
    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        //clamp current x, y position to screen position 
        //                              min value + object width      max value * -1 to make it positive - object width
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        //repeat for Y position
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        //set position to equal new altered position
        transform.position = viewPos;
    }

    //fixed update for running physics calculations
    private void FixedUpdate()
    {
        if (joystick.isActiveAndEnabled)
        {
            JoystickMovement();
        }
        else
        {
            Movement();
        }        
    }

    //move the player 
    private void Movement()
    {
        //keyboard controls
        //get the input for the X and Y axis
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //add the movement to the rb velocity
        rb.velocity = movement * moveSpeed;        
    }

    private void JoystickMovement()
    {
        //joystick controls
        joystickMovement.x = joystick.Horizontal;
        joystickMovement.y = joystick.Vertical;

        rb.velocity = joystickMovement * moveSpeed;
    }
}
