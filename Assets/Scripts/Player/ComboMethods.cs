using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboMethods : MonoBehaviour
{
    [SerializeField] private LayerMask EnemyLayer;
    [SerializeField] private float PunchLength;
    [SerializeField] private Transform punchPosition;
    private Dictionary<int, Func<bool>> ComboMethodDict;
    [SerializeField] private Animator animator;

    private void Start()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }

    public void InitializeDict()
    {
        ComboMethodDict = new Dictionary<int, Func<bool>>
        {
            { 1, RegularPunch },
            { 2, UppercutPunch },
            {11, PushPunch },
            {12, UppercutPush }
        };

        if(PunchLength == 0)PunchLength = 1;
        punchPosition = GameObject.FindGameObjectWithTag("PunchPosition").transform;
        
    }

    public Dictionary<int, Func<bool>> GetDictionary()
    {
        return ComboMethodDict;
    }

    bool RegularPunch()
    {
        RaycastHit2D hit = Physics2D.Raycast(punchPosition.position, Vector2.right * Math.Sign(transform.localScale.x),
            PunchLength, EnemyLayer);
        Debug.DrawRay(punchPosition.position, Vector2.right * Math.Sign(transform.localScale.x), Color.red, 2f);

        if (hit)
        {
            hit.transform.gameObject.GetComponent<IDamageable>().ApplyDamage(5);
            gameObject.GetComponent<IFreezeable>().Freeze(0.3f);
            Debug.Log("regular punch!");
        }

        animator.SetBool("IsPunching", true);
        return true;
    }

    bool UppercutPunch()
    {
        Vector2 forwardVector = Vector2.right * Math.Sign(transform.localScale.x);
        RaycastHit2D hit = Physics2D.Raycast(punchPosition.position, forwardVector,
            PunchLength, EnemyLayer);
        Debug.DrawRay(punchPosition.position, forwardVector, Color.red, 2f);

        if (hit)
        {
            hit.transform.gameObject.GetComponent<IDamageable>().ApplyDamage(10);
            Debug.Log("high punch!");
        }
        
        return true;
    }

    bool PushPunch()
    {
        Vector2 forwardVector = Vector2.right * Math.Sign(transform.localScale.x);
        RaycastHit2D hit = Physics2D.Raycast(punchPosition.position,  forwardVector,
            PunchLength, EnemyLayer);
        Debug.DrawRay(punchPosition.position, forwardVector, Color.red, 2f);

        if (hit)
        {
            hit.transform.gameObject.GetComponent<IPushable>().ApplyForce(200 * forwardVector.x, 0);
            Debug.Log("final punch!");
        }
        return true;
    }

    bool UppercutPush()
    {
        Vector2 forwardVector = Vector2.right * Math.Sign(transform.localScale.x);
        RaycastHit2D hit = Physics2D.Raycast(punchPosition.position, forwardVector,
            PunchLength, EnemyLayer);
        Debug.DrawRay(punchPosition.position, forwardVector, Color.red, 2f);

        if (hit)
        {
            gameObject.GetComponent<IFreezeable>().Freeze(0.3f);
            hit.transform.gameObject.GetComponent<IPushable>().ApplyForce(50 * forwardVector.x, 380);
            Debug.Log("uppercut punch!");
        }

        return true;
    }
}
