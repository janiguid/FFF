using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondJump : PickUp
{

    public override void Collect()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController pCon;
            if (collision.TryGetComponent<PlayerController>(out pCon))
            {
                pCon.AlterJumpAbility(1);
            }

            Destroy(gameObject);
        }
    }
}
