using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : Hazard
{
    [SerializeField] float xForceMultiplier;
    [SerializeField] float yForceMultiplier;
    [SerializeField] Rigidbody2D spike;
    private Transform firena;

    private void Start()
    {
        if (xForceMultiplier == 0) xForceMultiplier = 15;
        if (yForceMultiplier == 0) yForceMultiplier = 15;
        spike.bodyType = RigidbodyType2D.Static;
        firena = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float dist = GetDistance(spike.position, firena.position);
        if(dist < 8)
        {
            spike.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    float GetDistance(Vector2 origin, Vector2 target)
    {
        float xDist = Mathf.Pow((origin.x - target.x), 2);
        float yDist = Mathf.Pow((origin.y - target.y), 2);

        return Mathf.Sqrt(xDist + yDist);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IDamageable damageable;
            IPushable pushable;

            if (collision.gameObject.GetComponent<ITargetable>().IsTargetable() == false) return;

            if (collision.gameObject.TryGetComponent<IDamageable>(out damageable))
            {

                damageable.ApplyDamage(damage);
            }
            else
            {
                print("Missing damageable");
            }

            if (collision.gameObject.TryGetComponent<IPushable>(out pushable))
            {
                Vector3 myCenter = GetComponent<SpriteRenderer>().bounds.center;
                float xForce = collision.transform.position.x - myCenter.x;
                float yForce = collision.transform.position.y - myCenter.y;
                pushable.ApplyForce(xForce * xForceMultiplier, yForce * yForceMultiplier);
                Debug.DrawLine(myCenter, collision.transform.position, Color.red, 5f);
            }
            else
            {
                print("Missing forceAble");
            }

        }

        gameObject.SetActive(false);
    }

}
