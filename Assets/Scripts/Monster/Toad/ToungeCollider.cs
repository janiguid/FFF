using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToungeCollider : MonoBehaviour
{
    [SerializeField] private string targetTag;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == targetTag)
        {
            if (collision.GetComponent<ITargetable>().IsTargetable())
            {
                print(transform.localScale);
                IDamageable[] dam = collision.GetComponents<IDamageable>();
                IFreezeable[] freezeables = collision.GetComponents<IFreezeable>();
                IPushable push = collision.GetComponent<IPushable>();
                for (int i = 0; i < dam.Length; ++i)
                {
                    dam[i].ApplyDamage(1);
                }

                for (int i = 0; i < freezeables.Length; ++i)
                {
                    freezeables[i].Freeze(1);
                }


                float xVel = 50 * Mathf.Sign(transform.parent.localScale.x);
                print(xVel);
                push.ApplyForce(xVel, 20);
            }
        }
    }
}
