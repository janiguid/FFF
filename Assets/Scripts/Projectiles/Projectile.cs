using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float direction;
    Rigidbody2D myRigidBody;
    public float speed;
    public int damage;
    public float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        lifetime = 4;
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        myRigidBody.velocity = Vector2.right * speed * Time.deltaTime * direction;

        if(lifetime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            DamageDetector player = collision.gameObject.GetComponent<DamageDetector>();
            if (player)
            {
                player.ApplyDamage(10);
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Player doesn't have damage detector. Make sure to attach.", gameObject);
            }
        }

        
    }
}
