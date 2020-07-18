using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CursorManager : MonoBehaviour
{
    [SerializeField] private float cursorSpeed;
    InputActions Inputs;
    [SerializeField] private Vector2 movement;
    [SerializeField] private float length;
    [SerializeField] private Transform originPoint;
    [SerializeField] private Transform centerPosition;
    [SerializeField] private GameObject fireball;
    [SerializeField] private float fireballSpeed;

    private void Start()
    {
        Inputs.FlightMovement.Fire.started += _ =>Fire();

        centerPosition = FindObjectOfType<PlayerController>().transform;
        transform.position = centerPosition.position;
            
    }

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
        movement += Inputs.FlightMovement.Cursor.ReadValue<Vector2>();

        //movement.x = Mathf.Clamp(movement.x, -1, 1);
        //movement.y = Mathf.Clamp(movement.y, -1, 1);

        transform.position = movement;

    }

    void Fire()
    {
        GameObject tem = GameObject.Instantiate(fireball);
        tem.transform.position = originPoint.position;
        Vector3 target = transform.position - originPoint.position;
        tem.GetComponent<Projectile>().SetTarget(target, fireballSpeed);
    }
}
