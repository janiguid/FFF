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
    [SerializeField] private ParticleSystem particleSys;
    [SerializeField] private AudioSource audioSrc;
    [SerializeField] private bool isAlive;
    [SerializeField] private Vector2 target;


    public  enum targetTag
    {
        Player, 
        Enemy
    }

    [SerializeField] private targetTag targettedTag;
    
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        lifetime = 4;
        if(myRigidBody == null) myRigidBody = GetComponent<Rigidbody2D>();
        if (particleSys == null) particleSys = GetComponentInChildren<ParticleSystem>();
        if (audioSrc == null) audioSrc = GetComponent<AudioSource>();
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

        if(target == null || target == Vector2.zero)
        {
            myRigidBody.velocity = transform.right * speed;
        }
        else
        {
            //transform.position = Vector2.MoveTowards(transform.position, target, .5f);
            myRigidBody.velocity = target * speed;
        }
        
    }

    public void SetTarget(Vector2 tgt, Vector2 originalPos)
    {
        target = tgt;
        Vector2 transformPos = new Vector2(transform.position.x, transform.position.y);
        var dir = originalPos - transformPos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle += 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void SetTargetTag(targetTag tag)
    {
        targettedTag = tag;
    }

    IEnumerator SelfDestruct(float timeTilDeath)
    {
        if (!gameObject.activeSelf) yield return null;
        if (particleSys && audioSrc)
        {
            audioSrc.Play();
            particleSys.Play();
            yield return new WaitForSeconds(particleSys.main.duration);
            
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == targettedTag.ToString())
        {
            print("Detected player");
            IDamageable[] player = collision.gameObject.GetComponents<IDamageable>();

            if (player != null)
            {
                foreach (IDamageable damageable in player) damageable.ApplyDamage(10);
                isAlive = false;
                myRigidBody.velocity = Vector2.zero;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                
            }
            else
            {
                Debug.Log("Player doesn't have damage detector. Make sure to attach.", gameObject);
            }

            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            StartCoroutine(SelfDestruct(1));
        }

        
    }
}
