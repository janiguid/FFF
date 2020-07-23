using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour, IDamageable
{
    [SerializeField] private float InitialHealth;
    protected float health;

    private void Start()
    {
        if (InitialHealth == 0) InitialHealth = 50f;
        health = InitialHealth;
    }

    public virtual void ApplyDamage(float dam) { }




}
