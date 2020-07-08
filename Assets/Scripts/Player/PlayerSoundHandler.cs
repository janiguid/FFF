using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundHandler : MonoBehaviour
{
    [SerializeField] private AudioSource firstJumpSound;
    [SerializeField] private AudioSource secondJumpSound;
    [SerializeField] private AudioSource flightAscentSound;
    [SerializeField] private AudioSource flightDescentSound;
    [SerializeField] private AudioSource footstepsSound;
    [SerializeField] private AudioSource landingSound;

    private PlayerController playerController;
    private InputActions inputActions;
    private bool inFlight;
    private bool inAir;


    private Dictionary<PlayerSoundType, AudioSource> AudioDictionary;
    public enum PlayerSoundType
    {
        firstJump,
        secondJump,
        flightAscent,
        flightDescent, 
        footsteps,
        landingSound
    }

    private void Awake()
    {
        inputActions = new InputActions();
        inputActions.LandMovement.Jump.performed += _ => PlayJumpSound();
        inputActions.LandMovement.ToggleFlight.started += _ => PlayFlightSound();
        inputActions.LandMovement.Move.started += _ => BeginWalkSounds();
        inputActions.LandMovement.Move.canceled += _ => StopWalkSounds();
        inFlight = false;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void OnDestroy()
    {
        inputActions.LandMovement.Jump.performed -= _ => PlayJumpSound();
        inputActions.LandMovement.ToggleFlight.started -= _ => PlayFlightSound();
        inputActions.LandMovement.Move.started -= _ => BeginWalkSounds();
        inputActions.LandMovement.Move.canceled -= _ => StopWalkSounds();
    }

    private void Start()
    {
        AudioDictionary = new Dictionary<PlayerSoundType, AudioSource>();
        AudioDictionary.Add(PlayerSoundType.firstJump, firstJumpSound);
        AudioDictionary.Add(PlayerSoundType.secondJump, secondJumpSound);
        AudioDictionary.Add(PlayerSoundType.flightAscent, flightAscentSound);
        AudioDictionary.Add(PlayerSoundType.flightDescent, flightDescentSound);
        AudioDictionary.Add(PlayerSoundType.footsteps, footstepsSound);
        AudioDictionary.Add(PlayerSoundType.landingSound, landingSound);

        playerController = GetComponent<PlayerController>();
    }

    void PlayFlightSound()
    {
        print("hit play");
        if (AudioDictionary[PlayerSoundType.flightAscent].isPlaying)
        {
            AudioDictionary[PlayerSoundType.flightAscent].Stop();
        }

        if (inFlight)
        {
            PlayPlayerSound(PlayerSoundType.flightDescent);
        }
        else
        {
            PlayPlayerSound(PlayerSoundType.flightAscent);
        }

        inFlight = !inFlight;
    }

    void PlayJumpSound()
    {
        if (playerController.enabled == false) return;
        int jumpsLeft = playerController.GetRemainingJumps();

        if (jumpsLeft == 0) return;

        StopWalkSounds();

        if (jumpsLeft == 2)
        {
            PlayPlayerSound(PlayerSoundType.firstJump);
        }
        else if (jumpsLeft == 1) 
        {
            PlayPlayerSound(PlayerSoundType.secondJump);
        }

        inAir = true;
    }

    public void PlayPlayerSound(PlayerSoundType soundType)
    {
        if(AudioDictionary.Count == 0)
        {
            print("ERROR: Nothing in audio dictionary");
        }
        AudioDictionary[soundType].Play();
    }

    public void PlayContinuously(PlayerSoundType soundType)
    {
        if (AudioDictionary[soundType].isPlaying) return;

        if (inFlight) return;
        AudioDictionary[soundType].Play();
    }

    void BeginWalkSounds()
    {
        if (inFlight ||inAir ) return;
        PlayContinuously(PlayerSoundType.footsteps);
    }

    void StopWalkSounds()
    {
        AudioDictionary[PlayerSoundType.footsteps].Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            PlayPlayerSound(PlayerSoundType.landingSound);
            inAir = false;
        }
    }
}
