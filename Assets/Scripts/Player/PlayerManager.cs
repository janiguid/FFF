﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float initialPlayerHealth;
    [SerializeField] private float playerHealth;
    [SerializeField] private float initialWingValue;
    [SerializeField] private float wingValue;

    [SerializeField] private DamageDetector damageDetector;
    private HealthBar health;
    private WingBar wings;
    private GameObject player;



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

        if (playerHealth <= 0)
        {
            playerHealth = 0;
            player = GameObject.FindWithTag("Player");
            player.transform.position = new Vector2(-53, 24);
            RegainHealth(initialPlayerHealth);
            print(playerHealth);
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            SceneManager.LoadScene(1);
        }
        
        if (health)
        {
            health.SetHealth(playerHealth);
        }

        print("Player manager received delegate call");
    }

    public void RegainHealth(float value)
    {
        playerHealth += value;

        if (playerHealth > initialPlayerHealth)
        {
            playerHealth = initialPlayerHealth;
        }

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
