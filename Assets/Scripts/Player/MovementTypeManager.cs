using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTypeManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private FlightController flightController;

    [SerializeField] private ParticleSystem particles;
    private Animator anim;

    InputActions Inputs;

    private void Awake()
    {
        Inputs = new InputActions();

    }

    void Start()
    {
        if(particles == null)
        {
            particles = GetComponentInChildren<ParticleSystem>();
        }
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        flightController = GetComponent<FlightController>();

    }

    private void OnEnable()
    {
        Inputs.LandMovement.ToggleFlight.started += _ => ToggleMovement();
        Inputs.Enable();
    }

    private void OnDisable()
    {
        Inputs.LandMovement.ToggleFlight.started -= _ => ToggleMovement();
        Inputs.Disable();
    }

    void ToggleMovement()
    {
        if (playerController.isActiveAndEnabled)
        {
            anim.Play("Transform");
            particles.Play();
            flightController.enabled = true;
            playerController.enabled = false;
        }
        else
        {
            anim.Play("Idle");
            playerController.enabled = true;
            flightController.enabled = false;
        }
    }
}
