using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private InputActions Inputs;


    //Uncheck to use controller
    public bool useController;

    //PLAYER DATA RELATED
    public CharacterData playerData;


    //SPRITE AND LOOKS RELATED
    public SpriteRenderer sprite;


    Rigidbody2D rigidbody2D;
    Collider2D collider2D;
    [SerializeField]
    LayerMask layerMask;


    float gravityScale;
    float jumpVelocity;
    [SerializeField]
    float jumpHeight;
    [SerializeField]
    float jumpTime;

    public bool isGrounded;

    float additionalRay;

    public bool isFrozen;
    public float pauseTime;
    public Vector2 savedVelocity;

    public Vector2 horizontalVelocity;
    public float speed;
    public Vector3 spriteFlipper = new Vector3(-1, 1, 1);

    private void Awake()
    {
        Inputs = new InputActions();
        
    }

    private void OnEnable()
    {
        Inputs.Enable();
    }

    private void OnDisable()
    {
        Inputs.Disable();
    }

    

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;

        additionalRay = 0.4f;
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();




        gravityScale = (2*jumpHeight / Mathf.Pow(jumpTime, 2));
        jumpVelocity = gravityScale * jumpTime;

        rigidbody2D.gravityScale = gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            rigidbody2D.gravityScale = 1;
        }
        else
        {
            rigidbody2D.gravityScale = gravityScale;
        }


        VerticalMovement();
        HorizontalMovement();

        if (isFrozen)
        {
            pauseTime -= Time.deltaTime;
            rigidbody2D.velocity = Vector2.zero;
        }

        if(pauseTime <= 0 && isFrozen && !isGrounded)
        {
            isFrozen = false;
            rigidbody2D.velocity = Vector2.zero;
            savedVelocity = Vector2.zero;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.tag);
        if (collision.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print(collision.tag + "exit" );
        if (collision.tag == "Ground")
        {
            isGrounded = false;
        }
    }


    void VerticalMovement()
    {
        

        //if (useController)
        //{
            
        //    if ((Input.GetKeyDown(KeyCode.Space) && isGrounded) || (Input.GetAxisRaw("VerticalGamePad") > 0.1) && isGrounded)
        //    {
        //        print("blah");
        //        rigidbody2D.velocity = Vector2.up * jumpVelocity;
        //    }
        //}
        //else
        //{
        //    if ((Input.GetKeyDown(KeyCode.Space) && isGrounded) || (Input.GetAxisRaw("Vertical") > 0.1 && isGrounded))
        //    {
        //        rigidbody2D.velocity = Vector2.up * jumpVelocity;
        //    }
        //}


        //if ((Input.GetButtonDown("Square") || Input.GetButtonDown("Triangle")) && !isGrounded && !isFrozen && playerData.pauseTime > 0f)
        //{
        //    pauseTime = playerData.pauseTime;
        //    savedVelocity = rigidbody2D.velocity;
        //    rigidbody2D.velocity = Vector2.zero;
        //    isFrozen = true;
        //}
    }

    void HorizontalMovement()
    {


        //if (useController)
        //{
        //    horizontalVelocity.x = speed * Input.GetAxis("HorizontalGamePad");
        //}
        //else
        //{
        //    horizontalVelocity.x = speed * Input.GetAxis("Horizontal");
        //}

        //horizontalVelocity.y = rigidbody2D.velocity.y;

        //rigidbody2D.velocity = horizontalVelocity;

        //if(horizontalVelocity.x < 0 && playerData.GetDirection() > 0)
        //{
        //    SetDirection(-1);
        //}
        //else if(horizontalVelocity.x > 0 && playerData.GetDirection() < 0)
        //{
        //    SetDirection(1);

        //}
    }

    void SetDirection(int direction)
    {
        playerData.SetDirection(direction);
        //sprite.flipX = !sprite.flipX;
        spriteFlipper = transform.localScale;
        spriteFlipper.x = -spriteFlipper.x;
        transform.localScale = spriteFlipper;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        print("Jumping");
    }
}
