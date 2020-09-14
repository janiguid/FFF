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

            Destroy(gameObject);
        }
    }
}
