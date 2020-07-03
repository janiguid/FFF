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

    public enum JumpType
    {
        Normal,
        Double,
        Flight
    }



    [SerializeField] private bool usingController;

    private InputActions Inputs;
    private Rigidbody2D RB_2D;

    private void Awake()
    {
        Inputs = new InputActions();
    }

    // Start is called before the first frame update
    void Start()
    {
        RB_2D = GetComponent<Rigidbody2D>();
        Inputs.Land.Jump.performed += _ => Jump();

        gravityScale = (2 * jumpHeight / Mathf.Pow(jumpTime, 2));
        jumpVelocity = gravityScale * jumpTime;

        RB_2D.gravityScale = gravityScale;
        RefreshJump();
    }

    private void OnEnable()
    {
        Inputs.Enable();
    }

    private void OnDisable()
    {
        Inputs.Disable();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMovement = Inputs.Land.Move.ReadValue<float>();


        movement.x = Vector2.right.x * horizontalMovement * speed;

        if (!isGrounded)
        {
            movement.y -= gravityScale * Time.deltaTime;
        }

        RB_2D.velocity = movement;
    }

    void Jump()
    {
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
        print(collision.tag);
        if (collision.tag == "Ground")
        {
            isGrounded = true;
            movement.y = 0;
            RefreshJump();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print(collision.tag + "exit");
        if (collision.tag == "Ground")
        {
            isGrounded = false;
        }
    }

}
