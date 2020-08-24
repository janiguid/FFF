using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float direction;
    [SerializeField] private Rigidbody2D myRigidBody;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private float lifetime;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private bool isAlive;
    [SerializeField] private Vector2 target;
    [SerializeField] private LayerMask targetLayer;
    
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        lifetime = 4;
        if(myRigidBody == null) myRigidBody = GetComponent<Rigidbody2D>();
        if (particleSystem == null) particleSystem = GetComponentInChildren<ParticleSystem>();
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
        if (isAlive == false) return;

        if(target == null)
        {
            myRigidBody.velocity = transform.right * speed;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target, .5f);
        }
        
    }

    public void SetTarget(Vector2 tgt)
    {
        target = tgt * 10;
    }

    IEnumerator SelfDestruct(float timeTilDeath)
    {

        particleSystem.Play();
        yield return new WaitForSeconds(particleSystem.main.duration);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != targetLayer) return;
        if(collision.gameObject.tag == "Player")
        {
            IDamageable[] player = collision.gameObject.GetComponents<IDamageable>();

            if (player != null)
            {
                foreach (IDamageable damageable in player) damageable.ApplyDamage(10);
                isAlive = false;
                myRigidBody.velocity = Vector2.zero;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(SelfDestruct(1));
            }
            else
            {
                Debug.Log("Player doesn't have damage detector. Make sure to attach.", gameObject);
            }
        }

        
    }
}
