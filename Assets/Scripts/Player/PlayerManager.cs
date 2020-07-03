using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    [SerializeField] private float InitialPlayerHealth;
    [SerializeField] private float PlayerHealth;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth = InitialPlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage(float dam)
    {
        PlayerHealth -= dam;
    }
}
