using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{

    private InputActions Inputs;
    private Rigidbody2D RB_2D;

    public float HorizontalMovement;
    public float VerticalMovement;

    [SerializeField]
    private Vector2 Movement;

    public float Speed;
    public bool isGrounded;

    [SerializeField]
    private float gravityScale;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private float jumpTime;
    [SerializeField]
    private float jumpVelocity;

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
        HorizontalMovement = Inputs.Land.Move.ReadValue<float>();

        Movement.x = Vector2.right.x * HorizontalMovement * Speed;

        if (!isGrounded)
        {
            Movement.y -= gravityScale * Time.deltaTime;
        }

        RB_2D.velocity = Movement;
    }

    void Jump()
    {
        print("Blah");
        Movement.y = Vector2.up.y * jumpVelocity;
        isGrounded = false;
        //RB_2D.velocity = Vector2.up * jumpVelocity;

        //RB_2D.AddForce(Vector2.up * jumpVelocity);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.tag);
        if (collision.tag == "Ground")
        {
            isGrounded = true;
            Movement.y = 0;
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    print(collision.tag + "exit");
    //    if (collision.tag == "Ground")
    //    {
    //        isGrounded = false;
    //    }
    //}

}
