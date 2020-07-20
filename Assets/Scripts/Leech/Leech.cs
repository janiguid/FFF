using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leech : Monster
{
    [SerializeField] private float timeForTravelling;
    [SerializeField] private float distBeforeBreaking;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject projectilePrefab;
    private Transform target;


    public override void ApplyDamage(float dam)
    {
        health -= dam;
    }


    private void Start()
    {
        if (timeForTravelling == 0) timeForTravelling = 5;
        if (distBeforeBreaking == 0) distBeforeBreaking = 2;

        if (layerMask != LayerMask.GetMask("Player")) layerMask = LayerMask.GetMask("Player");
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
            dist = GetDistance(transform.position, target.position);
            transform.LookAt(target);
        }

        
        if(dist > 5 + distBeforeBreaking)
        {
            target = null;
        }
        
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
            transform.Rotate(0, 180, 0);
        }

        print(transform.right);
        transform.Translate( transform.right * Time.deltaTime, Space.World);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 5, layerMask);
        Debug.DrawRay(transform.position, transform.right * 5);
        if (hit.collider == null)
        {

        }
        else
        {
            target = hit.transform;
        }
    }

    private void OnDrawGizmos()
    {
        
    }
}
