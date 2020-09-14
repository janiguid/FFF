using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToadManager : MonoBehaviour, IDamageable, IFreezeable, IPushable
{
    [SerializeField] private string targetTag;

    private float health;
    private Animator anim;
    private PlayerManager player;


    // Start is called before the first frame update
    void Start()
    {
        health = 50;
        player = FindObjectOfType<PlayerManager>();
        anim = GetComponent<Animator>();
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
        health -= (dam);
        if (health <= 0) Destroy(gameObject);

        anim.SetBool("ReceivedDamage", true);
    }

    public void Freeze(float freezeDuration)
    {
    }

    public void ApplyForce(float horizontalForce, float verticalForce)
    {
    }
}
