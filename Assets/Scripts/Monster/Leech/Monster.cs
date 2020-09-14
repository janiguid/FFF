using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    [SerializeField] protected float InitialHealth;
    [SerializeField] protected float health;

    private void Start()
    {

    }

    public virtual void ApplyDamage(float dam) { }

    public virtual void ApplyForce(float horizontalForce, float verticalForce)
    {
    }
}
