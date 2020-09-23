using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] ParticleSystem pSystem;
    [SerializeField] float damage;
    [SerializeField] float waitTime;
    [SerializeField] bool canJuggle;
    [SerializeField] bool canPush;

    //can Push is regulated by animations
    private WaitForSecondsRealtime waitPeriod;

    private void Start()
    {
        waitPeriod = new WaitForSecondsRealtime(waitTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (pSystem) pSystem.Play();
            collision.GetComponent<IDamageable>().ApplyDamage(damage);
            collision.GetComponent<IFreezeable>().Freeze(0.3f);

            if (player)
            {
                if (player.GetIsInAir())
                {
                    player.gameObject.GetComponent<IFreezeable>().Freeze(1f);
                    collision.GetComponent<IPushable>().ApplyForce(0, 50);
                    collision.GetComponent<IFreezeable>().Freeze(1f);
                    
                }
            }

            Vector2 forwardVector = Vector2.right * Mathf.Sign(transform.parent.parent.localScale.x);
            if (canJuggle)
            {
                
                collision.GetComponent<IPushable>().ApplyForce(0, 400);
                print("Should be juggling");
            }

            if (canPush)
            {
                collision.GetComponent<IPushable>().ApplyForce(200 * forwardVector.x, 0);
            }
            StartCoroutine(HitStop());
        }
        
    }

    IEnumerator HitStop()
    {
        //if (Time.timeScale == 0) yield break;
        Time.timeScale = 0;
        yield return waitPeriod;
        Time.timeScale = 1;

    }


}
