using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboMethods : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float punchLength;
    [SerializeField] private Transform punchPosition;
    private Dictionary<int, Func<bool>> comboMethodDict;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource firenaGrunt;


    /* For VFX
     * 0 = regular punch
     * 1 = strong punch
     * 2 = reg kick
     * 3 = strong kcik
    */
    [Header("Particle Systems")]
    [SerializeField] private ParticleSystem[] particleSystems;

    private void Start()
    {
        if (animator == null) animator = GetComponent<Animator>();

        if (enemyLayer.value != 13)
        {
            print("ENEMY LAYER ISN'T SET PROPERLY");
            enemyLayer = LayerMask.GetMask("EnemyDamageable");
            print(enemyLayer.value);
        }
    }

    public void InitializeDict()
    {
        comboMethodDict = new Dictionary<int, Func<bool>>
        {
            { 1, RegularPunch },
            { 2, RegularKick },
            {11, PushPunch },
            {12, HighKick }
        };

        if(punchLength == 0)punchLength = 1;
        punchPosition = GameObject.FindGameObjectWithTag("PunchPosition").transform;
    }

    public Dictionary<int, Func<bool>> GetDictionary()
    {
        return comboMethodDict;
    }

    bool RegularPunch()
    {
        RaycastHit2D hit = Physics2D.Raycast(punchPosition.position, Vector2.right * Math.Sign(transform.localScale.x),
            punchLength, enemyLayer);
        Debug.DrawRay(punchPosition.position, Vector2.right * Math.Sign(transform.localScale.x), Color.red, 2f);


        if (hit)
        {
            if (hit.transform.gameObject.GetComponent<ITargetable>().IsTargetable())
            {
                ApplyDamage(5, hit.transform.gameObject.GetComponents<IDamageable>());

                gameObject.GetComponent<IFreezeable>().Freeze(0.3f);

                if (particleSystems.Length != 0) particleSystems[0].Play();
            }

        }
        
        return true;
    }

    bool PushPunch()
    {
        Vector2 forwardVector = Vector2.right * Math.Sign(transform.localScale.x);
        RaycastHit2D hit = Physics2D.Raycast(punchPosition.position,  forwardVector,
            punchLength, enemyLayer);
        Debug.DrawRay(punchPosition.position, forwardVector, Color.red, 2f);

        if (hit)
        {
            if (hit.transform.gameObject.GetComponent<ITargetable>().IsTargetable())
            {
                ApplyDamage(10, hit.transform.gameObject.GetComponents<IDamageable>());
                hit.transform.gameObject.GetComponent<IPushable>().ApplyForce(200 * forwardVector.x, 0);

                if (particleSystems.Length != 0) particleSystems[1].Play();
            }


        }
        return true;
    }

    bool RegularKick()
    {
        Vector2 forwardVector = Vector2.right * Math.Sign(transform.localScale.x);
        RaycastHit2D hit = Physics2D.Raycast(punchPosition.position, forwardVector,
            punchLength, enemyLayer);
        Debug.DrawRay(punchPosition.position, forwardVector, Color.red, 2f);

        if (hit)
        {

            if (hit.transform.gameObject.GetComponent<ITargetable>().IsTargetable())
            {
                ApplyDamage(5, hit.transform.gameObject.GetComponents<IDamageable>());
                if (particleSystems.Length != 0) particleSystems[2].Play();
            }


        }

        //animator.Play("Base Layer.RegularKick", 0);
        return true;
    }

    bool HighKick()
    {
        Vector2 forwardVector = Vector2.right * Math.Sign(transform.localScale.x);
        RaycastHit2D hit = Physics2D.Raycast(punchPosition.position, forwardVector,
            punchLength, enemyLayer);
        Debug.DrawRay(punchPosition.position, forwardVector, Color.red, 2f);

        if (hit)
        {
            if (hit.transform.gameObject.GetComponent<ITargetable>().IsTargetable())
            {
                gameObject.GetComponent<IFreezeable>().Freeze(0.3f);
                ApplyDamage(15, hit.transform.gameObject.GetComponents<IDamageable>());
                hit.transform.gameObject.GetComponent<IPushable>().ApplyForce(50 * forwardVector.x, 380);
                if (particleSystems.Length != 0) particleSystems[3].Play();
            }

        }

        //animator.Play("Base Layer.HighKick", 0);

        return true;
    }

    void ApplyDamage(float dam, IDamageable[] damageables)
    {


        if(firenaGrunt != null)
        {
            if (firenaGrunt.isPlaying) firenaGrunt.Stop();
            firenaGrunt.Play();
        }

        foreach (IDamageable obj in damageables)
        {
            obj.ApplyDamage(dam);
        }
    }
}
