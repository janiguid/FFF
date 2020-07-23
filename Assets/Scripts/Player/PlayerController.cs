﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float gravityScale;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float jumpTime;
    [SerializeField] private float jumpVelocity;
    [SerializeField] private Vector2 movement;
    [SerializeField] private float horizontalMovement;
    [SerializeField] private float verticalMovement;
    [SerializeField] private float speed;
    [SerializeField] private bool isGrounded;
    [SerializeField] private int maxJumps;
    [SerializeField] private int jumpsLeft;
    [SerializeField] private bool isFacingRight;
    [SerializeField] private float minYVelocity;
    [SerializeField] private float maxYVelocity;

    private InputActions Inputs;
    private Rigidbody2D RB_2D;
    private SpriteRenderer SRenderer;
    

    private void Awake()
    {
        Inputs = new InputActions();
        Inputs.LandMovement.Jump.performed += _ => Jump();
    }

    // Start is called before the first frame update
    void Start()
    {
        RB_2D = GetComponent<Rigidbody2D>();


        InitializePhys();
        RefreshJump();

        
        SRenderer = GetComponent<SpriteRenderer>();
    }

    void InitializePhys()
    {
        gravityScale = (2 * jumpHeight / Mathf.Pow(jumpTime, 2));
        jumpVelocity = gravityScale * jumpTime;

        RB_2D.gravityScale = gravityScale;
    }

    private void OnEnable()
    {
        Inputs.Enable();

        if (RB_2D)
        {
            RB_2D.gravityScale = gravityScale;
            RB_2D.velocity = movement = Vector2.zero;
        }
        RefreshJump();
    }

    private void OnDisable()
    {
        
        Inputs.Disable();
    }

    private void OnDestroy()
    {
        Inputs.LandMovement.Jump.performed -= _ => Jump();
    }


    // Update is called once per frame
    void Update()
    {

        horizontalMovement = Inputs.LandMovement.Move.ReadValue<float>();


        movement.x = Vector2.right.x * horizontalMovement * speed;

        if (!isGrounded)
        {
            movement.y = Mathf.Clamp(movement.y - gravityScale * Time.deltaTime, minYVelocity, maxYVelocity);
            
        }

        RB_2D.velocity = movement;

        if ((isFacingRight && horizontalMovement < 0) || (!isFacingRight && horizontalMovement > 0))
        {
            Flip();
        }

    }

    public int GetRemainingJumps()
    {
        return jumpsLeft;
    }

    void Flip()
    {
        Vector2 turner = Vector2.left;
        turner.y += 1;
        transform.localScale *= turner;
        isFacingRight = !isFacingRight;
    }

    void Jump()
    {
        print("jump func called");
        if (jumpsLeft == 0) return;
        movement.y = Vector2.up.y * jumpVelocity;
        isGrounded = false;
        
        jumpsLeft -= 1;
    }

    void RefreshJump()
    {
        jumpsLeft = maxJumps;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGrounded = true;
            movement.y = 0;
            RefreshJump();
            print("Refreshed");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGrounded = false;
        }
    }

}
