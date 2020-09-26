using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    [SerializeField] protected float initialHealth;
    [SerializeField] protected bool isInAir;

    [SerializeField] protected float health;

    public float GetHealth()
    {
        return health;
    }
}
