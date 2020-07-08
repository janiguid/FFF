using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTypeManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private FlightController flightController;

    InputActions Inputs;

    private void Awake()
    {
        Inputs = new InputActions();

    }

    void Start()
    {
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
            flightController.enabled = true;
            playerController.enabled = false;
        }
        else
        {
            playerController.enabled = true;
            flightController.enabled = false;
        }
    }
}
