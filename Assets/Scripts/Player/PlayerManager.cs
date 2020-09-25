using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float initialPlayerHealth;
    [SerializeField] private float playerHealth;
    [SerializeField] private float initialWingValue;
    [SerializeField] private float wingValue;
    [SerializeField] private GameObject L2;
    [SerializeField] private DamageDetector damageDetector;
    private HealthBar health;
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

        print("Player manager received delegate call");
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
