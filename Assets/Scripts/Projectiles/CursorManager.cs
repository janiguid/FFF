using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CursorManager : MonoBehaviour
{
    [SerializeField] private float cursorSpeed;
    [SerializeField] private Vector2 movement;
    [SerializeField] private GameObject fireBall;
    [SerializeField] private float radius;



    InputActions Inputs;

    private void Awake()
    {
        Inputs = new InputActions();
    }

    private void Start()
    {

        Inputs.FlightMovement.Fireball.started += _ => FireProjectile();
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
        Vector2 lastKnownLoc = movement;

        if(movement.x == 0)
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
        temp.transform.position = transform.position;
        print("balh");
        temp.SetActive(false);
        temp.transform.position = Vector3.zero;
        temp.GetComponent<Projectile>().SetTarget(transform.position);
        temp.SetActive(true);
    }
}
