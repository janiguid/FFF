using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leech : Managers
{
    [SerializeField] private float shootCooldown;
    [SerializeField] private float timeForTravelling;
    [SerializeField] private float distBeforeBreaking;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Projectile.targetTag targetTag;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float eyesightLength;

    [Header("Timers")]
    [SerializeField] private float recoveryTimer;
    [SerializeField] private float timeBeforeRecovery;
    [SerializeField] private float shootTimer;


    [Header("Visual Effects")]
    [SerializeField] private ParticleSystem deathCloud;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform spitSource;

    [Header("Bounds")]
    [SerializeField] private Transform leftBound;
    [SerializeField] private Transform rightBound;
    [SerializeField] private Vector2 initialLeftBound;
    [SerializeField] private Vector2 initialRightBound;
    private float leftMax;
    private float rightMax;
    private Vector3 rot;


    private DamageDetector damDetector;
    private bool isTargetable;
    private Transform target;




    private void Start()
    {
        isTargetable = true;
        if (timeForTravelling == 0) timeForTravelling = 5;
        if (distBeforeBreaking == 0) distBeforeBreaking = 2;
        if (layerMask != LayerMask.GetMask("Player")) layerMask = LayerMask.GetMask("Player");

        if (initialHealth == 0) initialHealth = 50f;
        health = initialHealth;
        shootTimer = 2;

        if (damDetector)
        {
            damDetector.detectorDelegate += ApplyDamage;
        }
        else
        {
            damDetector = GetComponent<DamageDetector>();
            damDetector.detectorDelegate += ApplyDamage;
        }

        if(anim == null)
        {
            anim = GetComponent<Animator>();
        }

        if(leftBound && rightBound)
        {
            leftMax = leftBound.position.x;
            rightMax = rightBound.position.x;
            initialLeftBound = leftBound.position;
            initialRightBound = rightBound.position;
            positionToGoTo = initialRightBound;
            dir = 1;
        }
        else
        {
            leftMax = -3;
            rightMax = 3;
        }
    }



    private void Update()
    {
        if (health <= 0) return;
        
        if (recoveryTimer >= 0)
        {

            recoveryTimer -= Time.deltaTime;
            return;
        }

        float dist = 0;
        if (target == null)
        {
            LookForPlayer();
        }
        else
        {
            shootTimer -= Time.deltaTime;
            dist = GetDistance(transform.position, target.position);

            if (shootTimer <= 0)
            {
                shootTimer = shootCooldown;
                BeginShoot();
            }


        }

        


        CheckForPlayer();

    }

    public void ApplyDamage(float dam)
    {
        print("called func");
        anim.Play("Base Layer.Hit");
        if (health <= 0) return;
        recoveryTimer = timeBeforeRecovery;
        health -= dam;
        if (health <= 0)
        {
            isTargetable = false;
            StartCoroutine(PlayDeathAnimAndDie());
        }



    }

    IEnumerator PlayDeathAnimAndDie()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;

        deathCloud.Play();
        yield return new WaitForSeconds(deathCloud.main.duration);
    }

    void BeginShoot()
    {
        anim.Play("Spit");
        var proj = Instantiate(projectilePrefab, transform, false);
        proj.transform.position = spitSource.position;
        Projectile projInstance = proj.GetComponent<Projectile>();
        Vector2 tgt = target.transform.localPosition - transform.localPosition;
        projInstance.SetTarget(tgt.normalized, transform.localPosition);
        //projInstance.SetDir(dir);
        projInstance.GetComponent<Projectile>().SetTargetTag(targetTag);
    }

    float GetDistance(Vector2 origin, Vector2 target)
    {
        float xDist = Mathf.Pow((origin.x - target.x), 2);
        float yDist = Mathf.Pow((origin.y - target.y), 2);

        return Mathf.Sqrt(xDist + yDist);
    }

    public Vector2 positionToGoTo;
    public int dir;
    void LookForPlayer()
    {

        if (Mathf.Abs(transform.localPosition.x - initialRightBound.x) < 0.1) {
            if(positionToGoTo != initialLeftBound)
            {
                positionToGoTo = initialLeftBound;
                positionToGoTo.x -= 1;
                transform.SetXScale(-1);
                dir = -1;
            }   
        }
        else if(Mathf.Abs(transform.localPosition.x - initialLeftBound.x) < 0.1)
        {
            if(positionToGoTo != initialRightBound)
            {
                positionToGoTo = initialRightBound;
                positionToGoTo.x += 1;
                transform.SetXScale(1);
                dir = 1;
            }
            
        }


        transform.localPosition = Vector2.MoveTowards(transform.localPosition, positionToGoTo, Time.deltaTime);


    }

    bool CheckForPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * dir, eyesightLength, layerMask);
        Debug.DrawRay(transform.position, transform.right * eyesightLength * dir);
        if (hit.collider == null && target != null)
        {
            target = null;
            return false;
        }
        else
        {
            target = hit.transform;
            return true;
        }
    }


}
