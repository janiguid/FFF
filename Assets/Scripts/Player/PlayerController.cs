using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour, IDamageable
{
    [Header("Jump Settings")]
    [SerializeField] private float gravityScale;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float jumpTime;
    [SerializeField] private float jumpVelocity;
    [SerializeField] private float verticalMovement;

    [Header("Land Movement")]
    [SerializeField] private Vector2 movement;
    [SerializeField] private float horizontalMovement;
    [SerializeField] private float speed;

    [Header("Velocity Caps")]
    [SerializeField] private float minYVelocity;
    [SerializeField] private float maxYVelocity;

    [Header("Checks")]
    [SerializeField] private bool isGrounded;
    [SerializeField] private int maxJumps;
    [SerializeField] private int jumpsLeft;
    [SerializeField] private bool isFacingRight;
    [SerializeField] private bool isAttacking;

    [Header("Timers")]
    [SerializeField] private float timeBeforeRecovery;
    [SerializeField] private float recoveryTimer;


    [SerializeField] private Animator animator;
    private bool hasAnim;

    private InputActions Inputs;
    private Rigidbody2D RB_2D;
    private SpriteRenderer SRenderer;
    

    private void Awake()
    {
        Inputs = new InputActions();
        Inputs.LandMovement.Jump.performed += _ => Jump();
        Inputs.LandMovement.North.performed += _ => ShortFreeze();
        Inputs.LandMovement.West.performed += _ => ShortFreeze();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(RB_2D == null) RB_2D = GetComponent<Rigidbody2D>();


        InitializePhys();
        RefreshJump();

        if (timeBeforeRecovery == 0) timeBeforeRecovery = 0.1f;
        if (animator == null) gameObject.GetComponent<Animator>();

        if (animator != null) hasAnim = true;
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
        recoveryTimer -= Time.deltaTime;
        if (recoveryTimer >= 0) return;



        horizontalMovement = Inputs.LandMovement.Move.ReadValue<float>();

        if (hasAnim)
        {
            if (horizontalMovement != 0 && isGrounded)
            {
                if (animator.GetBool("IsRunning") == false)
                {
                   animator.SetBool("IsRunning", true);
                }
            }
            else
            {
                if (animator.GetBool("IsRunning") == true)
                {
                    animator.SetBool("IsRunning", false);
                }
            }
        }

        movement.x = Vector2.right.x * horizontalMovement * speed;


        if (!isGrounded)
        {
            movement.y = Mathf.Clamp(movement.y - gravityScale * Time.deltaTime, minYVelocity, maxYVelocity);

        }


        if ((isFacingRight && horizontalMovement < 0) || (!isFacingRight && horizontalMovement > 0))
        {
            Flip();
        }

    }

    private void FixedUpdate()
    {

        recoveryTimer -= Time.deltaTime;
        if (recoveryTimer >= 0) return;
        RB_2D.velocity = movement;


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

        if (animator)
        {
            if (animator.GetBool("IsJumping") == false)
            {
                animator.SetBool("IsJumping", true);
            }
        }

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

            if (animator)
            {
                if (animator.GetBool("IsJumping") == true)
                {
                    animator.SetBool("IsJumping", false);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGrounded = false;


        }
    }

    public void ApplyDamage(float dam)
    {
        ShortFreeze();
    }

    private void ShortFreeze()
    {
        movement = Vector2.zero;
        movement = Vector2.down;
        recoveryTimer = timeBeforeRecovery;
    }
}
