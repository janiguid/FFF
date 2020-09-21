﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leech : Monster, ITargetable
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

<<<<<<< HEAD
    [Header("Bounds")]
    [SerializeField] private Transform leftBound;
    [SerializeField] private Transform rightBound;
    public  float leftMax;
    public float rightMax;


=======
    
>>>>>>> FlightLimiter
    private DamageDetector damDetector;
    private bool isTargetable;
    private Transform target;




    private void Start()
    {
        isTargetable = true;
        if (timeForTravelling == 0) timeForTravelling = 5;
        if (distBeforeBreaking == 0) distBeforeBreaking = 2;
        if (layerMask != LayerMask.GetMask("Player")) layerMask = LayerMask.GetMask("Player");

        if (InitialHealth == 0) InitialHealth = 50f;
        health = InitialHealth;
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

<<<<<<< HEAD
        if(leftBound && rightBound)
        {
            leftMax = leftBound.position.x;
            rightMax = rightBound.position.x;

            if(leftMax > rightMax)
            {
                print("Error, you have your bounds mixed up!");
                float temp = leftMax;
                leftMax = rightMax;
                rightMax = temp;
            }
        }
        else
        {
            print("ERROR: Missing Left and Right Bound references");
            leftMax = transform.localPosition.x - 2;
            rightMax = transform.localPosition.x + 2;
=======
        if(anim == null)
        {
            anim = GetComponent<Animator>();
>>>>>>> FlightLimiter
        }
    }



    private void Update()
    {
        if (health <= 0) return;
        recoveryTimer -= Time.deltaTime;
        if (recoveryTimer >= 0) return;

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

        
        if(dist > 5 + distBeforeBreaking)
        {
            target = null;
        }

        CheckForPlayer();

    }

    public override void ApplyDamage(float dam)
    {
        print("called func");
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
        Destroy(gameObject);
    }

    void BeginShoot()
    {
        anim.Play("Spit");
        var GameObject = Instantiate(projectilePrefab, transform, false);
        GameObject.transform.position = spitSource.position;

        GameObject.GetComponent<Projectile>().SetTargetTag(targetTag);
    }

    float GetDistance(Vector2 origin, Vector2 target)
    {
        float xDist = Mathf.Pow((origin.x - target.x), 2);
        float yDist = Mathf.Pow((origin.y - target.y), 2);

        return Mathf.Sqrt(xDist + yDist);
    }

    void LookForPlayer()
    {
        //timeForTravelling -= Time.deltaTime;

        //if(timeForTravelling <= 0)
        //{
        //    timeForTravelling = 5;
        //    TurnAround(1);
        //}

        transform.Translate( transform.right * Time.deltaTime, Space.World);
        if(transform.localPosition.x > rightMax)
        {
            TurnAround(1);
        }else if(transform.localPosition.x < leftMax)
        {
            TurnAround(1);
        }

    }

    bool CheckForPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, eyesightLength, layerMask);
        Debug.DrawRay(transform.position, transform.right * eyesightLength);
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


    void TurnAround(int dir)
    {
        Vector3 rot = new Vector3(0, 180, 0) * dir;
        transform.Rotate(0, 180, 0);
    }



    public bool IsTargetable()
    {
        return isTargetable;
    }
}
