using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D MyRB2D;
    [SerializeField] private float speed;
    private VFXHandler MyVFX;

    InputActions Inputs;

    private void Awake()
    {
        Inputs = new InputActions();
        MyVFX = GetComponent<VFXHandler>();
    }

    private void Start()
    {
        
    }

    public void InitializeFlight()
    {
        MyRB2D = GetComponent<Rigidbody2D>();
        MyRB2D.gravityScale = 0;
    }

    private void Update()
    {
        MyRB2D.AddForce(Inputs.FlightMovement.Flight.ReadValue<Vector2>() * speed);
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
