using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTypeManager : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private FlightController flightController;
    [SerializeField] private ComboManager comboManager;
    [SerializeField] private ParticleSystem particles;

    [SerializeField] private float flightTimer;

    private float wingValueDecrementor;
    private WaitForSeconds waitTime;
    private PlayerManager pMan;
    private Animator anim;
    private Coroutine wingValueChecker;
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

        if(playerController == null) playerController = GetComponent<PlayerController>();
        if(flightController == null) flightController = GetComponent<FlightController>();
        if(comboManager == null) comboManager = GetComponent<ComboManager>();

        wingValueChecker = null;
        
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

            wingValueDecrementor = pMan.GetWingValue() / flightTimer;
            waitTime = new WaitForSeconds(1);
            wingValueChecker = StartCoroutine(FlightTimer());
            anim.Play("Transform");
            anim.SetBool("IsFlying", true);
            particles.Play();
        }
        else
        {
            EndFlight();
        }
    }

    void EndFlight()
    {
        particles.Play();
        anim.Play("Transform");
        anim.Play("Idle");
        anim.SetBool("IsFlying", false);
        flightController.enabled = false;
        playerController.enabled = true;
        StopCoroutine(wingValueChecker);
        comboManager.enabled = true;
    }

    IEnumerator FlightTimer()
    {
        if (!pMan) yield break;
        


        while(pMan.GetWingValue() > 0)
        {
            pMan.IncreaseWingValue(-wingValueDecrementor);
            print("Still decreasing");
            yield return waitTime;
        }

        EndFlight();

        yield break;
    }
}
