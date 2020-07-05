using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetector : MonoBehaviour, IDamageable, IPushable
{
    [SerializeField] private float gravityScale;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float jumpTime;
    [SerializeField] private float jumpVelocity;
    [SerializeField] private Vector2 movement;
    [SerializeField] private float horizontalMovement;
    [SerializeField] private float verticalMovement;

    //public CameraShakeTest CameraShaker;

    [SerializeField] private AudioSource MyAudio;

    [SerializeField] private CharacterData MyData;

    [SerializeField] private Rigidbody2D MyRB2D;

    public float staggerTime;
    public bool isFrozen;
    public Vector2 savedVelocity;

    public float freezeTime;
    public float fallingVelocity;

    // Start is called before the first frame update
    void Start()
    {
        MyAudio = GetComponent<AudioSource>();
        MyRB2D = GetComponent<Rigidbody2D>();

        InitializePhys();
    }

    void InitializePhys()
    {
        gravityScale = (2 * jumpHeight / Mathf.Pow(jumpTime, 2));
        jumpVelocity = gravityScale * jumpTime;

        MyRB2D.gravityScale = gravityScale;
    }

    // Update is called once per frame
    void Update()
    {

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

    //DAMAGE: damage to be applied to our character data
    public void ApplyDamage(float damage)
    {
        MyData.stunned = true;
        MyData.health -= damage;

        Freeze(freezeTime);
        print(gameObject.name + "received " + damage + "damage");

        ShakeCam();

        if (MyAudio)
        {
            MyAudio.Play();
        }
        
    }

    //Applies force to this character
    public void ApplyForce(float HorizontalForce, float VerticalForce)
    {
        isFrozen = false;
        MyRB2D.AddForce(new Vector2(HorizontalForce, VerticalForce), ForceMode2D.Impulse);
        ShakeCam();
        if (MyAudio)
        {
            MyAudio.Play();
        }
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
        //CameraShaker.StartShake();
    }


}
