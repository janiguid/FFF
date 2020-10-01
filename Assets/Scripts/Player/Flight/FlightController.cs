using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool isFacingRight;
    [SerializeField] private GameObject cursor;
    [SerializeField] private Rigidbody2D MyRB2D;
    [SerializeField] private DamageDetector damDec;
    [SerializeField] private Animator anim;
    [SerializeField] private PlayerSoundHandler audioSrc;

    private Vector2 inputValue;
    private VFXHandler MyVFX;

    InputActions Inputs;

    private void Awake()
    {
        Inputs = new InputActions();
        MyVFX = GetComponent<VFXHandler>();
    }

    private void Start()
    {
        if(MyRB2D == null)
        {
            MyRB2D = GetComponent<Rigidbody2D>();
        }
    }


    public void InitializeFlight()
    {
        MyRB2D = GetComponent<Rigidbody2D>();
        MyRB2D.gravityScale = 0;
    }

    private void Update()
    {
        inputValue = Inputs.FlightMovement.Flight.ReadValue<Vector2>();

        if (inputValue.x > 0.2f || inputValue.x < -0.2f)
        {
            transform.SetXScale((int)Mathf.Sign(inputValue.x));
        }
    }

    private void FixedUpdate()
    {
        MyRB2D.AddForce(inputValue * speed);

    }

    private void OnEnable()
    {
        MyVFX.BeginAura();
        InitializeFlight();
        Inputs.Enable();
        cursor.SetActive(true);
        if (damDec) damDec.detectorDelegate += PlayHitAnim;
    }

    void PlayHitAnim(float a)
    {
        anim.Play("Base Layer.FlyDamaged");
    }

    private void OnDisable()
    {
        audioSrc.StopSound(PlayerSoundHandler.PlayerSoundType.flightAscent);
        MyVFX.StopAura();
        Inputs.Disable();
        cursor.SetActive(false);

        if (damDec) damDec.detectorDelegate -= PlayHitAnim;
    }


}
