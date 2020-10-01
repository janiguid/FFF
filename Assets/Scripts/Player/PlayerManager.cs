using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float initialPlayerHealth;
    [SerializeField] private float playerHealth;
    [SerializeField] private float initialWingValue;
    [SerializeField] private float wingValue;
    [SerializeField] private GameObject L2;
    [SerializeField] private DamageDetector damageDetector;
    [SerializeField] private PlayerSoundHandler soundHandler;
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
            
            
            if (soundHandler)
            {
                AudioManager.Instance.StopAudio();
                soundHandler.PlayPlayerSound(PlayerSoundHandler.PlayerSoundType.deathSound);

            }


            SceneManager.LoadScene(1);
            ResetCharacter();
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            transform.position = new Vector2(-53, 26);
        }
        
        if (health)
        {
            health.SetHealth(playerHealth);
        }

        print("Player manager received delegate call");
    }

    private void OnLevelWasLoaded(int level)
    {
        AudioManager.Instance.StopAudio();
        if(level == 1) transform.position = new Vector2(-53, 24);
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
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

        if(wingValue >= 50)
        {
            wingValue = 50;
        }

        if(L2 != null)
        {
            if (wings && wingValue >= 50 && L2 && L2.activeSelf == false)
            {
                L2.SetActive(true);
            }
            else if (L2.activeSelf == true && L2 && wingValue < 50)
            {
                L2.SetActive(false);
            }
        }

    }


    public float GetWingValue()
    {
        return wingValue;
    }

    private void ResetCharacter()
    {
        wingValue = initialWingValue;
        playerHealth = initialPlayerHealth;
        GetComponent<PlayerController>().AlterJumpAbility(1);
    }
}
