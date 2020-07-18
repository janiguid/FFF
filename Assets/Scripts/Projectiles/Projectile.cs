using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float direction;
    public Rigidbody2D myRigidBody;
    public float speed;
    public int damage;
    public float lifetime;

    [SerializeField] private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        lifetime = 4;
        myRigidBody = GetComponent<Rigidbody2D>();
        myRigidBody.AddForce(target);
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        

        if(lifetime < 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetTarget(Vector2 tar, float spd)
    {
        speed = spd;
        tar.Normalize();
        target = tar * speed;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            IDamageable player = collision.gameObject.GetComponent<IDamageable>();
            if (player != null)
            {
                player.ApplyDamage(10);
            }
            else
            {
                Debug.Log("Player doesn't have damage detector. Make sure to attach.", gameObject);
            }
        }

        
    }
}
