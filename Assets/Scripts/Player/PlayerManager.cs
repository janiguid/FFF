using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    [SerializeField] private float initialPlayerHealth;
    [SerializeField] private float playerHealth;
    public HealthBar health;

    // Start is called before the first frame update
    void Start()
    {
        if (health == null)
        {
            health = FindObjectOfType<HealthBar>();
        }
        playerHealth = initialPlayerHealth;
        health.SetMaxHealth(initialPlayerHealth);

    }


    public void ApplyDamage(float dam)
    {
        playerHealth -= dam;
        health.SetHealth(playerHealth);

        if (playerHealth <= 0) Destroy(gameObject);
    }
}
