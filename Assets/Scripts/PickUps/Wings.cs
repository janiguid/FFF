using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wings : PickUp
{
    [SerializeField] private float wingValue;

    public override void Collect()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerManager pMan;
            if (collision.TryGetComponent<PlayerManager>(out pMan))
            {
                pMan.IncreaseWingValue(wingValue);
            }

            Destroy(gameObject);
        }
    }
}
