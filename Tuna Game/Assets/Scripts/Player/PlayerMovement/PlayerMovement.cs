using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    float horizontalInput;
    float verticalInput;
    
    Vector3 moveDirecton;

    public Transform playerOrientation;

    Rigidbody rb;

    [Header("Keybinds")]

    public KeyCode jumpKey = KeyCode.Space;

    //we must check player is on ground so that we do not apply drag when the player is in the air
    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;



   

   

    private void Start()
    {
        //assign rigidbody and freeze it's rotation 

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        //get ready to jump
        readyToJump = true;
    }



    private void Update()
    {

        //call speed control function
        SpeedControl();

        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        //call input function
        MyInput();

        //handle drag

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    { 
        //call MovePlayer function
        MovePlayer();
    }
    private void MyInput()
    {
        //get keyboard inputs
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");  
        
        //check when to jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            //if all true then call jump function and set readyToJump to false
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        //calculate movement direction
        moveDirecton = playerOrientation.forward * verticalInput + playerOrientation.right * horizontalInput;

        //if on ground
        if(grounded)
            rb.AddForce(moveDirecton.normalized * moveSpeed * 10f, ForceMode.Force);

        //in air
        else if(!grounded)
            rb.AddForce(moveDirecton.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    //limit player speed manually
    private void SpeedControl()
    {
        //get flat velocity of rigidbody
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //check if player goes faster than movement speed
        if (flatVel.magnitude > moveSpeed)

        {// then calculate what max velocity would be
            Vector3 limitedVel = flatVel.normalized * moveSpeed;

            //apply limited velocity
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);

        }
    }

    private void Jump()
    {
        //reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}
