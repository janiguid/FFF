using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CursorManager : MonoBehaviour
{
    [SerializeField] private float cursorSpeed;
    InputActions Inputs;
    Vector2 movement;


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

    // Update is called once per frame
    void Update()
    {
        movement += Inputs.FlightMovement.Cursor.ReadValue<Vector2>() * Time.deltaTime *cursorSpeed;
        transform.position = movement;
    }
}
