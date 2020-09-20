using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float waitTime;
    private WaitForSecondsRealtime waitPeriod;

    private void Start()
    {
        waitPeriod = new WaitForSecondsRealtime(waitTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<IDamageable>().ApplyDamage(damage);
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
