using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    [SerializeField] private float initialPlayerHealth;
    [SerializeField] private float playerHealth;
    [SerializeField] private float initialWingValue;
    [SerializeField] private float wingValue;

    private HealthBar health;
    private WingBar wings;

    // Start is called before the first frame update
    void Start()
    {
        if (health == null)
        {
            health = FindObjectOfType<HealthBar>();
        }

        if(wings == null)
        {
            wings = FindObjectOfType<WingBar>();
        }

        wingValue = initialWingValue;
        playerHealth = initialPlayerHealth;

        if (health)
        {
            health.SetMaxHealth(initialPlayerHealth);
        }

        if (wings)
        {
            wings.SetMax(50f);
            wings.SetWingValue(initialWingValue);
        }
        

    }


    public void ApplyDamage(float dam)
    {
        playerHealth -= dam;

        if (health)
        {
            health.SetHealth(playerHealth);
        }
        

        if (playerHealth <= 0) Destroy(gameObject);
    }

    public void RegainHealth(float value)
    {
        playerHealth += value;

        if (health)
        {
            health.SetHealth(playerHealth);
        }
    }

    public void IncreaseWingValue(float value)
    {
        wingValue += value;

        if (wings)
        {
            wings.SetWingValue(wingValue);
        }
    }


    public float GetWingValue()
    {
        return wingValue;
    }
}
