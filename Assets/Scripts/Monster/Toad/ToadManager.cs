using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToadManager : MonoBehaviour, IDamageable, IFreezeable, IPushable
{
    [SerializeField] private string targetTag;
    private PlayerManager player;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerManager>();

        if (targetTag == "") targetTag = "Player";
    }

    public bool HasPlayer()
    {
        if (player) return true;

        return false;
    }

    public Vector3 GetPlayerPosition()
    {
        return player.transform.position;
    }


    public void ApplyDamage(float dam)
    {
        
    }

    public void Freeze(float freezeDuration)
    {
    }

    public void ApplyForce(float horizontalForce, float verticalForce)
    {
    }
}
