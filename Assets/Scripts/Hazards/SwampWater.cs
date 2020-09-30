using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwampWater : Hazard
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable dam;

        if(collision.TryGetComponent<IDamageable>(out dam))
        {
            dam.ApplyDamage(damage);
        }
    }
}
