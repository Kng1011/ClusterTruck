using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;




public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;
    public int jumpCount;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;
    bool jumpOnTruck;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public LayerMask grap;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    TruckMovement truck;

    Rigidbody rb;
    public bool freeze = false;
    public bool activegrapple;
    private Vector3 velocityToSet;
    private bool enableMovementOnNextTouch;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.4f, grap);

        if (grounded)
        {
            rb.drag = groundDrag;
            jumpCount = 1;
        }
        else
            rb.drag = 0;

        MyInput();
        SpeedControl();

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (UnityEngine.Input.GetKeyDown(jumpKey) && readyToJump && grounded)
        {          
            readyToJump = false;
            jumpCount = 2;
            jumpCount--; 
            Jump();
            

            Invoke(nameof(ResetJump), jumpCooldown);


        }

        if (UnityEngine.Input.GetKeyDown(jumpKey) && readyToJump && !grounded && jumpCount > 0)
        {
            Jump();
            jumpCount--;
            Invoke(nameof(ResetJump), jumpCooldown);
            

        }


        if (UnityEngine.Input.GetKeyDown(jumpKey) && jumpOnTruck)
        {
            Jump();
            jumpCount--;
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }
    private void MovePlayer()
    {
        if (activegrapple)
        {
            return;
        }

        // Calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // On ground
        if (grounded & readyToJump)
        {
            // Stop player if no input
            if (horizontalInput == 0 && verticalInput == 0 )
            {
                rb.velocity = Vector3.zero;
            }
            else
            {
                // Movement
                rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            }
        }
        // In air
        else
        {
            // Movement in air
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }

        
    }



    private void SpeedControl()
    {

        if (activegrapple)
        {
            return;
        }

        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        //rb.velocity = new Vector3(rb.velocity.x, jumpForce);


        rb.velocity = new Vector3(rb.velocity.x, jumpForce * 0.5f, rb.velocity.z);

        // Adicionar uma força na direção do movimento horizontal
        Vector3 horizontalMoveDirection = moveDirection;
        horizontalMoveDirection.y = 0f; // Remove qualquer componente vertical
        rb.AddForce(horizontalMoveDirection.normalized * jumpForce * 0.5f, ForceMode.Impulse); // Ajuste o fator multiplicador para controlar a força horizontal do salto

        //rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Truck")
        {
            jumpOnTruck = true;
            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Truck")
        {
            jumpOnTruck = false;
        }
    }

    public Vector3 CalculateJumpVelocity(Vector3 startPoint, Vector3 endPoint, float trajectoryHeight)
    {
        float gravity = Physics.gravity.y;
        float displacementY = endPoint.y - startPoint.y;
        Vector3 displacementXZ = new Vector3(endPoint.x - startPoint.x, 0f, endPoint.z - startPoint.z);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * trajectoryHeight);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * trajectoryHeight / gravity)
            + Mathf.Sqrt(2 * (displacementY - trajectoryHeight) / gravity));

        return velocityXZ + velocityY;
    }


    private void SetVelocity()
    {
        enableMovementOnNextTouch = true;
        rb.velocity = velocityToSet;
    }

    public void JumpToPosition(Vector3 targetPosition, float trajectoryHeight)
    {
        activegrapple = true;

        velocityToSet = CalculateJumpVelocity(transform.position, targetPosition, trajectoryHeight);
        Invoke(nameof(SetVelocity), 0.1f);

        Invoke(nameof(ResetRestrictions), 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (enableMovementOnNextTouch)
        {
            enableMovementOnNextTouch = false;
            ResetRestrictions();

            GetComponent<Grappling>().StopGrapple();
        }

        
    }


    public void ResetRestrictions()
    {
        activegrapple = false;
    }

}

