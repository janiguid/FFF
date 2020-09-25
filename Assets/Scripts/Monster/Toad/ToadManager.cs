using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(DamageDetector))]
public class ToadManager : MonoBehaviour
{
    [SerializeField] private string targetTag;
    [SerializeField] private DamageDetector damageDetector;
    [SerializeField] private float initialHealth;


    private float health;
    private Animator anim;
    private PlayerManager player;



    // Start is called before the first frame update
    void Start()
    {
        health = initialHealth;
        player = FindObjectOfType<PlayerManager>();
        anim = GetComponent<Animator>();
        if (targetTag == "") targetTag = "Player";

        damageDetector.detectorDelegate += ApplyDamage;
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

    private void OnDisable()
    {
        damageDetector.detectorDelegate -= ApplyDamage;
    }
    public void ApplyDamage(float dam)
    {
        health -= (dam);
        if (health <= 0) Destroy(gameObject);

        anim.SetBool("ReceivedDamage", true);
    }

    public float s;
    private void OnMouseDown()
    {
        print("wth");
        float playerLoc = FindObjectOfType<PlayerManager>().transform.position.x;
        s = playerLoc - transform.position.x;
        s *= (1 / 3) + (1 % 3);
        GetComponent<Rigidbody2D>().velocity = new Vector2(s, 31.6f);
    }

}
