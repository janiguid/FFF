using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{

    private InputActions Inputs;
    private Rigidbody2D RB_2D;

    public float HorizontalMovement;

    private void Awake()
    {
        Inputs = new InputActions();
    }

    // Start is called before the first frame update
    void Start()
    {
        RB_2D = GetComponent<Rigidbody2D>();
        Inputs.Land.Jump.performed += _ => Jump();


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
    }

    void Jump()
    {
        print("Leedle");
    }
}
