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
        //if(enemyLayer.value != 13)
        //{
        //    print("ENEMY LAYER ISN'T SET PROPERLY");
        //    enemyLayer.value = 13;
        //    print(enemyLayer.value);
        //}
        
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
            hit.transform.gameObject.GetComponent<IDamageable>().ApplyDamage(5);
            gameObject.GetComponent<IFreezeable>().Freeze(0.3f);

            particleSystems[0].Play();
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
            hit.transform.gameObject.GetComponent<IPushable>().ApplyForce(200 * forwardVector.x, 0);
            particleSystems[1].Play();
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
            hit.transform.gameObject.GetComponent<IDamageable>().ApplyDamage(10);
            particleSystems[2].Play();
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
            gameObject.GetComponent<IFreezeable>().Freeze(0.3f);
            hit.transform.gameObject.GetComponent<IPushable>().ApplyForce(50 * forwardVector.x, 380);
            particleSystems[3].Play();
        }

        //animator.Play("Base Layer.HighKick", 0);

        return true;
    }
}
