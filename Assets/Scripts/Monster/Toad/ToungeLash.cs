using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToungeLash : StateMachineBehaviour
{
    [SerializeField] private float minDistance;
    [SerializeField] private float currDistance;
    [SerializeField] private float cooldown;
    ToadManager toad;
    Rigidbody2D rb;
    Transform transform;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transform = animator.GetComponent<Transform>();
        animator.TryGetComponent<ToadManager>(out toad);
        rb = animator.GetComponent<Rigidbody2D>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (toad.HasPlayer())
        {
            currDistance = Vector2.Distance(animator.transform.position, toad.GetPlayerPosition());
            if (currDistance > minDistance)
            {
                animator.SetBool("PlayerWithinRange", false);
            }
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat("ToungeLashCD", cooldown);
    }


}
