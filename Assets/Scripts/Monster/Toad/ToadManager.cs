using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToadManager : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == targetTag)
        {
            print(Mathf.Sign(transform.localScale.x));
            IDamageable[] dam = collision.GetComponents<IDamageable>();
            IPushable push = collision.GetComponent<IPushable>();
            for(int i = 0; i < dam.Length; ++i)
            {
                dam[i].ApplyDamage(1);
            }

            push.ApplyForce(-50, 20);
        }
    }
}
