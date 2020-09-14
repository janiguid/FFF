using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalagmite : Hazard
{
    [SerializeField] float xForceMultiplier;
    [SerializeField] float yForceMultiplier;

    private void Start()
    {
        if (xForceMultiplier == 0) xForceMultiplier = 15;
        if (yForceMultiplier == 0) yForceMultiplier = 15;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
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
                pushable.ApplyForce(xForce*xForceMultiplier, yForce*yForceMultiplier);
                Debug.DrawLine(myCenter, collision.transform.position, Color.red, 5f);
            }
            else
            {
                print("Missing forceAble");
            }

        }
    }
}
