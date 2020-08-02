using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D MyRB2D;
    [SerializeField] private float speed;
    [SerializeField] private bool isFacingRight;

    private Vector2 inputValue;
    private VFXHandler MyVFX;


    InputActions Inputs;

    private void Awake()
    {
        Inputs = new InputActions();
        MyVFX = GetComponent<VFXHandler>();
    }

    private void Start()
    {
        if(MyRB2D == null)
        {
            MyRB2D = GetComponent<Rigidbody2D>();
        }
    }

    public void InitializeFlight()
    {
        MyRB2D = GetComponent<Rigidbody2D>();
        MyRB2D.gravityScale = 0;
    }

    private void Update()
    {
        inputValue = Inputs.FlightMovement.Flight.ReadValue<Vector2>();

        if(isFacingRight && (inputValue.x < -0.1f) || !isFacingRight && inputValue.x > 0.1f)
        {
            Flip();
        }
        MyRB2D.AddForce(inputValue * speed);
    }

    void Flip()
    {
        Vector2 turner = Vector2.left;
        turner.y += 1;
        transform.localScale *= turner;
        isFacingRight = !isFacingRight;
    }

    private void OnEnable()
    {
        MyVFX.BeginAura();
        InitializeFlight();
        Inputs.Enable();
    }

    private void OnDisable()
    {
        MyVFX.StopAura();
        Inputs.Disable();
    }


}
