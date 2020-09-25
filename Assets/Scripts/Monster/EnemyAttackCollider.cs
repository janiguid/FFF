using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCollider : MonoBehaviour
{
    [SerializeField] ToadManager player;
    [SerializeField] ParticleSystem pSystem;
    [SerializeField] float damage;
    [SerializeField] float waitTime;
    [SerializeField] bool canJuggle;
    [SerializeField] bool canPush;


    [SerializeField] float yForce;
    [SerializeField] float xForce;
    //can Push is regulated by animations
    private WaitForSecondsRealtime waitPeriod;

    private void Start()
    {
        waitPeriod = new WaitForSecondsRealtime(waitTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (pSystem) pSystem.Play();
            collision.GetComponent<IDamageable>().ApplyDamage(damage);
            collision.GetComponent<IFreezeable>().Freeze(0.3f);


            Vector2 forwardVector = Vector2.right * Mathf.Sign(transform.parent.parent.localScale.x);
            if (canJuggle)
            {
                //0, 400
                collision.GetComponent<IPushable>().ApplyForce(xForce, yForce);
                print("Should be juggling");
            }

            if (canPush)
            {
                //200, 0
                collision.GetComponent<IPushable>().ApplyForce(xForce * forwardVector.x, 0);
            }
            StartCoroutine(HitStop());
        }

    }

    IEnumerator HitStop()
    {
        waitPeriod.waitTime = waitTime;
        Time.timeScale = 0;
        yield return waitPeriod;
        Time.timeScale = 1;
    }


}
