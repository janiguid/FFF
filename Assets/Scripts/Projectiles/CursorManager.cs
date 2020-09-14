using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CursorManager : MonoBehaviour
{
    [SerializeField] private float cursorSpeed;
    [SerializeField] private Vector2 movement;
    [SerializeField] private GameObject fireBall;
    [SerializeField] private float radius;


    private Transform playerTransform;
    InputActions Inputs;

    private void Awake()
    {
        Inputs = new InputActions();
    }

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform;
        Inputs.FlightMovement.Fireball.started += _ => FireProjectile();
    }

    private void OnEnable()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform;
        Inputs.Enable();
    }

    private void OnDisable()
    {
        Inputs.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        movement.y += Inputs.FlightMovement.Cursor.ReadValue<Vector2>().y * Time.deltaTime * cursorSpeed;

        if(playerTransform.localScale.x > 0)
        {
            movement.x += Inputs.FlightMovement.Cursor.ReadValue<Vector2>().x * Time.deltaTime * cursorSpeed;
        }
        else
        {
            movement.x -= Inputs.FlightMovement.Cursor.ReadValue<Vector2>().x * Time.deltaTime * cursorSpeed;
        }
        

        //movement = Inputs.FlightMovement.Cursor.ReadValue<Vector2>() * cursorSpeed;

        //Vector2 lastKnownLoc = movement;

        //if (playerTransform.localScale.x < 0)
        //{
        //    movement.x *= -1;
        //}


        Vector2 lastKnownLoc = movement;

        if (movement.x == 0)
        {
            movement.x = lastKnownLoc.x;
        }

        if(movement.y == 0)
        {
            movement.y = lastKnownLoc.y;
        }

        movement.x = Mathf.Clamp(movement.x, -radius, radius);
        movement.y = Mathf.Clamp(movement.y, -radius, radius);
        transform.localPosition = movement;
    }

    void FireProjectile()
    {
        var temp = Instantiate(fireBall);
        print(transform.parent.position);
        temp.transform.position = transform.parent.position;
        
        temp.SetActive(false);

        Vector2 correctTarget = transform.localPosition;
        correctTarget.x *= Mathf.Sign(transform.parent.localScale.x);

        print(correctTarget);
        temp.GetComponent<Projectile>().SetTarget(correctTarget);
        temp.SetActive(true);
    }
}
