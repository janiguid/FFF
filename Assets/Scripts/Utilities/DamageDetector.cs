using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetector : MonoBehaviour, IDamageable, IPushable, IFreezeable, ITargetable
{
    [Header("Velocity Handlers")]
    [SerializeField] private float gravityScale;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float jumpTime;
    [SerializeField] private float jumpVelocity;


    //public CameraShakeTest CameraShaker;
    [SerializeField] private AudioSource MyAudio;
    [SerializeField] private CharacterData MyData;
    [SerializeField] private Rigidbody2D MyRB2D;
    [SerializeField] private CameraShakeTest camShake;

    [Header("Timers")]
    [SerializeField] private float staggerTime;
    [SerializeField] private bool isFrozen;
    [SerializeField] private Vector2 savedVelocity;
    [SerializeField] private float freezeTime;
    [SerializeField] private float fallingVelocity;
    [SerializeField] private float initialImmunityTime;
    [SerializeField] private float immunityTimer;
    [SerializeField] private bool canBeTargeted;

    // Start is called before the first frame update
    void Start()
    {
        if(MyAudio == null) MyAudio = GetComponent<AudioSource>();
        if(MyRB2D == null) MyRB2D = GetComponent<Rigidbody2D>();
        if (camShake == null) camShake = FindObjectOfType<CameraShakeTest>();
        canBeTargeted = true;
        InitializePhys();
    }

    void InitializePhys()
    {
        if(jumpHeight <= 0 || jumpTime <= 0)
        {
            jumpHeight = 5;
            jumpTime = 0.4f;
        }
        gravityScale = (2 * jumpHeight / Mathf.Pow(jumpTime, 2));
        jumpVelocity = gravityScale * jumpTime;

        MyRB2D.gravityScale = gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (immunityTimer > 0) immunityTimer -= Time.deltaTime;
        if (immunityTimer <= 0 && canBeTargeted == false) canBeTargeted = true;

        //if character is frozen, keep it freezed
        //until timer runs out
        if (isFrozen)
        {
            staggerTime -= Time.deltaTime;
            MyRB2D.velocity = Vector2.zero;
        }

        ////if timer runs out, make character go down
        if (staggerTime <= 0)
        {
            isFrozen = false;
        }
    }

    public bool IsTargetable()
    {
        if (canBeTargeted)
        {
            canBeTargeted = false;
            immunityTimer = initialImmunityTime;
            return true;
        }

        return false;
    }

    //DAMAGE: damage to be applied to our character data
    public void ApplyDamage(float damage)
    {
        //FreezeTime(1);
        //Freeze(freezeTime);
        ShakeCam();

        if (MyAudio)
        {
            MyAudio.Play();
        }

    }



    //Applies force to this character
    public void ApplyForce(float HorizontalForce, float VerticalForce)
    {
        print("force applied");
        isFrozen = false;
        MyRB2D.velocity = Vector2.zero;
        MyRB2D.AddForce(new Vector2(HorizontalForce, VerticalForce), ForceMode2D.Impulse);
        ShakeCam();
        if (MyAudio)
        {
            MyAudio.Play();
        }
    }


    void FreezeTime(float duration)
    {
        StartCoroutine(Freezer(duration));
    }


    //instead of waiting for 0.3 seconds for animation to finish, we can 
    //change the time scale of the animation to be unscaled with time,
    //making it independent of time
    IEnumerator Freezer(float duration)
    {
        yield return new WaitForSecondsRealtime(0.3f);
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1;
    }

    //This function saves the current velocity of this entity and 
    //changes it to zero, effectively "freezing" the character
    //PAUSETIME: amount of time to freeze velocity for
    public void Freeze(float pauseTime)
    {

        savedVelocity = MyRB2D.velocity;
        
        staggerTime = pauseTime;
        isFrozen = true;
    }

    public void ShakeCam()
    {
        if (camShake)
        {
            camShake.StartShake();
        }
        
    }


}
