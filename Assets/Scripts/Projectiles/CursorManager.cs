using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CursorManager : MonoBehaviour
{
    [SerializeField] private float cursorSpeed;
    [SerializeField] private Vector3 movement;
    [SerializeField] private GameObject fireBall;
    [SerializeField] private float radius;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform fireballStartPoint;
    [SerializeField] private AudioSource audioSrc;

    private Transform playerTransform;
    private InputActions Inputs;

    public Vector3 centerPosition;
    private Vector2 lastKnownLoc;
    public Vector3 distanceFromCenter;


    private Camera mainCam;
    private void Awake()
    {
        Inputs = new InputActions();
    }

    private void Start()
    {
        centerPosition = transform.localPosition;
        playerTransform = FindObjectOfType<PlayerController>().transform;
        Inputs.FlightMovement.Fireball.started += _ => FireProjectile();

        if (audioSrc == null) TryGetComponent<AudioSource>(out audioSrc);

        mainCam = Camera.main;
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
        //movement.y = Camera.main.ScreenToWorldPoint(Inputs.FlightMovement.Cursor.ReadValue<Vector2>()).y * Time.deltaTime * cursorSpeed;

        //if(playerTransform.localScale.x > 0)
        //{
        //    //movement.x += Inputs.FlightMovement.Cursor.ReadValue<Vector2>().x * Time.deltaTime * cursorSpeed;
        //    movement.x = Camera.main.ScreenToWorldPoint(Inputs.FlightMovement.Cursor.ReadValue<Vector2>()).x * Time.deltaTime * cursorSpeed;
        //}
        //else
        //{
        //    //movement.x -= Inputs.FlightMovement.Cursor.ReadValue<Vector2>().x * Time.deltaTime * cursorSpeed;
        //    movement.x -= Inputs.FlightMovement.Cursor.ReadValue<Vector2>().x * Time.deltaTime * cursorSpeed;
        //}

        movement = mainCam.ScreenToWorldPoint(Inputs.FlightMovement.Cursor.ReadValue<Vector2>());

        // lastKnownLoc = movement;

        //if (movement.x == 0)
        //{
        //    movement.x = lastKnownLoc.x;
        //}

        //if(movement.y == 0)
        //{
        //    movement.y = lastKnownLoc.y;
        //}

        //float dist = Vector2.Distance(movement, centerPosition);

        //if (dist > radius)
        //{
        //    //movement.x = Mathf.Clamp(movement.x, -radius, radius);
        //    //movement.y = Mathf.Clamp(movement.y, -radius, radius);
        //    //movement.z = -1;
        //    distanceFromCenter = movement - centerPosition;
        //    //distanceFromCenter.Normalize();
        //    distanceFromCenter *= radius / dist;

        //    movement = centerPosition + distanceFromCenter;
        //}

        movement.z = -1;
        transform.position = movement;
    }

    void FireProjectile()
    {
        if (audioSrc) audioSrc.Play();
        var temp = Instantiate(fireBall);
        if (anim) anim.Play("Base Layer.FireballAttack");
        temp.transform.position = transform.parent.position;
        temp.SetActive(false);

        Vector2 correctTarget = transform.localPosition;
        correctTarget.x *= Mathf.Sign(transform.parent.localScale.x);

        print(correctTarget);
        temp.GetComponent<Projectile>().SetTarget(correctTarget, transform.position);
        temp.SetActive(true);
    }
}
