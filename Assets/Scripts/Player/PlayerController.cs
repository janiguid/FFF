using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
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
    [SerializeField] private bool isJumping;

    [Header("Timers")]
    [SerializeField] private float timeBeforeRecovery;
    [SerializeField] private float recoveryTimer;
    [SerializeField] private float attackPauseTimer;


    [SerializeField] private Animator animator;
    private bool hasAnim;

    private InputActions Inputs;
    private Rigidbody2D RB_2D;
    private SpriteRenderer SRenderer;
    [SerializeField] private DamageDetector damageDetector;

    private void Awake()
    {
        Inputs = new InputActions();
        Inputs.LandMovement.Jump.performed += _ => Jump();
        Inputs.LandMovement.North.performed += _ => ShortFreeze();
        Inputs.LandMovement.West.performed += _ => ShortFreeze();

        if (damageDetector == null) damageDetector = GetComponent<DamageDetector>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(RB_2D == null) RB_2D = GetComponent<Rigidbody2D>();

        

        //if (damageDetector) damageDetector.detectorDelegate += ApplyDamage;

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
        if (damageDetector) damageDetector.detectorDelegate += ApplyDamage;
        Inputs.Enable();

        if (RB_2D)
        {
            RB_2D.gravityScale = gravityScale;
            RB_2D.velocity = movement = Vector2.down * maxYVelocity * 0.5f;
        }
        RefreshJump();
    }

    private void OnDisable()
    {
        if (damageDetector) damageDetector.detectorDelegate -= ApplyDamage;
        Inputs.Disable();
    }

    private void OnDestroy()
    {
        Inputs.LandMovement.Jump.performed -= _ => Jump();
    }


    // Update is called once per frame
    void Update()
    {
        if (recoveryTimer >= 0)
        {
            recoveryTimer -= Time.deltaTime;
            return;
        }



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


        if (horizontalMovement != 0)
        {
            transform.SetXScale((int)Mathf.Sign(horizontalMovement));
        }

    }

    private void FixedUpdate()
    {

        if (recoveryTimer >= 0) return;
        RB_2D.velocity = movement;


    }

    public int GetRemainingJumps()
    {
        return jumpsLeft;
    }



    void Jump()
    {
        if (jumpsLeft == 0) return;
        movement.y = Vector2.up.y * jumpVelocity;
        isGrounded = false;

        if (hasAnim)
        {
            //if (animator.GetBool("IsJumping") == false)
            //{
            //    animator.SetBool("IsJumping", true);
            //}
            isJumping = true;
            animator.Play("Jump");
        }

        jumpsLeft -= 1;
    }

    void RefreshJump()
    {
        jumpsLeft = maxJumps;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.enabled == false) return;
        if (collision.tag == "Ground")
        {
            isGrounded = true;
            movement.y = 0;
            RefreshJump();
            print("Refreshed");

            if (hasAnim)
            {
                if (animator.GetBool("IsJumping") == true)
                {
                    animator.SetBool("IsJumping", false);
                }

                isJumping = false;
                animator.Play("Land");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (this.enabled == false) return;
        if (collision.tag == "Ground")
        {
            isGrounded = false;
            if (!isJumping && hasAnim) animator.Play("Drop");

        }
    }

    public void ApplyDamage(float dam)
    {
        print("Player controller received delegate call");
        ShortFreeze();

        animator.Play("Damaged");
    }

    private void ShortFreeze()
    {
        //movement = Vector2.zero;
        //movement = Vector2.down;
        RB_2D.velocity = movement;
        recoveryTimer = attackPauseTimer;
    }

    public bool GetIsInAir()
    {
        return isJumping;
    }

    public void EnhanceJumpAbility()
    {
        maxJumps += 1;
        RefreshJump();
    }
}
