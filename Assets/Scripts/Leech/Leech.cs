using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leech : Monster, IDamageable
{
    [SerializeField] private float shootCooldown;
    [SerializeField] private float timeForTravelling;
    [SerializeField] private float distBeforeBreaking;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject projectilePrefab;

    private Transform target;
    private float shootTimer;


    public override void ApplyDamage(float dam)
    {
        health -= dam;
        if (health <= 0) Destroy(gameObject);
    }

    public override void ApplyForce(float horizontalForce, float verticalForce)
    {

    }

    private void Start()
    {
        if (timeForTravelling == 0) timeForTravelling = 5;
        if (distBeforeBreaking == 0) distBeforeBreaking = 2;
        if (layerMask != LayerMask.GetMask("Player")) layerMask = LayerMask.GetMask("Player");

        if (InitialHealth == 0) InitialHealth = 50f;
        health = InitialHealth;
        
    }

    private void Update()
    {
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

    void BeginShoot()
    {
        Instantiate(projectilePrefab, transform, false);
    }

    float GetDistance(Vector2 origin, Vector2 target)
    {
        float xDist = Mathf.Pow((origin.x - target.x), 2);
        float yDist = Mathf.Pow((origin.y - target.y), 2);

        return Mathf.Sqrt(xDist + yDist);
    }

    void LookForPlayer()
    {
        timeForTravelling -= Time.deltaTime;

        if(timeForTravelling <= 0)
        {
            timeForTravelling = 5;
            TurnAround(1);
        }

        transform.Translate( transform.right * Time.deltaTime, Space.World);


    }

    bool CheckForPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 5, layerMask);
        Debug.DrawRay(transform.position, transform.right * 5);
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
        Vector3 rot = new Vector3(0,180,0) * dir;
        transform.Rotate(0, 180, 0);
    }


}
