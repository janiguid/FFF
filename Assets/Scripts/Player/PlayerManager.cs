using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    [SerializeField] private float InitialPlayerHealth;
    [SerializeField] private float PlayerHealth;
    public HealthBar health;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth = InitialPlayerHealth;
        health.SetMaxHealth(InitialPlayerHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage(float dam)
    {
        PlayerHealth -= dam;
        health.SetHealth(PlayerHealth);
    }
}
