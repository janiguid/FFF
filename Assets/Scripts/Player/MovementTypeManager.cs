using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTypeManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private FlightController flightController;
    [SerializeField] private ComboManager comboManager;
    [SerializeField] private ParticleSystem particles;

    private PlayerManager pMan;
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

        if(pMan == null)
        {
            pMan = GetComponent<PlayerManager>();
        }
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        flightController = GetComponent<FlightController>();
        comboManager = GetComponent<ComboManager>();
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
            if (pMan)
            {
                if(pMan.GetWingValue() < 50)
                {
                    return;
                }
            }


            comboManager.enabled = false;
            flightController.enabled = true;
            playerController.enabled = false;

            anim.Play("Transform");
            anim.SetBool("IsFlying", true);
            particles.Play();
        }
        else
        {
            anim.Play("Idle");
            flightController.enabled = false;
            playerController.enabled = true;
            
            comboManager.enabled = true;
        }
    }
}
