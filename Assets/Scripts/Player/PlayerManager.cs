using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(DamageDetector))]
public class PlayerManager : Managers
{
    [SerializeField] private float initialWingValue;
    [SerializeField] private float wingValue;
    [SerializeField] private GameObject L2;
    [SerializeField] private DamageDetector damageDetector;
    private HealthBar healthBar;
    private WingBar wings;

    

    // Start is called before the first frame update
    void Start()
    {

        if (damageDetector == null) GetComponent<DamageDetector>();
        if (damageDetector)
        {
            damageDetector.detectorDelegate += ApplyDamage;
        }
        else
        {
            print("couldn't find dma dec");
        }

        if (healthBar == null)
        {
            healthBar = FindObjectOfType<HealthBar>();
        }

        if(wings == null)
        {
            wings = FindObjectOfType<WingBar>();
        }

        wingValue = initialWingValue;
        health = initialHealth;

        if (healthBar)
        {
            healthBar.SetMaxHealth(initialHealth);
        }

        if (wings)
        {
            wings.SetMax(50f);
            wings.SetWingValue(initialWingValue);
        }
        

    }


    public void ApplyDamage(float dam)
    {
        health -= dam;

        if (healthBar)
        {
            healthBar.SetHealth(health);
        }

        if (health <= 0) Destroy(gameObject);

        print("Player manager received delegate call");
    }

    public void RegainHealth(float value)
    {
        health += value;

        if (healthBar)
        {
            healthBar.SetHealth(health);
        }
    }

    public void IncreaseWingValue(float value)
    {
        wingValue += value;

        if (wings)
        {
            wings.SetWingValue(wingValue);
        }

        if(wingValue == 50)
        {
            if (L2) L2.SetActive(true);
        }
        else
        {
            if (L2) L2.SetActive(false);
        }
    }


    public float GetWingValue()
    {
        return wingValue;
    }
}
