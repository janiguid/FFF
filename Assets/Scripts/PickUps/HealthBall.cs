using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBall : PickUp
{
    [SerializeField] private float healthValue;

    public override void Collect()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerManager pMan;
            if(collision.TryGetComponent<PlayerManager>(out pMan))
            {
                pMan.RegainHealth(healthValue);
            }

            StartCoroutine(BeginDeath());
        }
    }


    public override IEnumerator BeginDeath()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        AudioSource audio;
        
        if(TryGetComponent<AudioSource>(out audio))
        {
            audio.Play();
        }
        else
        {
            yield return null;
        }

        while (audio.isPlaying)
        {
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
        yield return null;
    }
}
