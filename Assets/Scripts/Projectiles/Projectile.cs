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
        

        if(lifetime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        myRigidBody.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            IDamageable[] player = collision.gameObject.GetComponents<IDamageable>();

            if (player != null)
            {
                foreach (IDamageable damageable in player) damageable.ApplyDamage(10);
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Player doesn't have damage detector. Make sure to attach.", gameObject);
            }
        }

        
    }
}
