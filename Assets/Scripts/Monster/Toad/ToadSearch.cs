using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToadSearch : StateMachineBehaviour
{
    [SerializeField] private float minDistance;
    [SerializeField] private float currDistance;
    [SerializeField] private float speed;
    ToadManager toad;
    Rigidbody2D rb;
    Transform transform;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        transform = animator.GetComponent<Transform>();
        animator.TryGetComponent<ToadManager>(out toad);
        rb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {



        if (toad.HasPlayer())
        {
            currDistance = Vector2.Distance(animator.transform.position, toad.GetPlayerPosition());

            //Debug.Log("Current Distance: " + currDistance);
            if (currDistance > minDistance && animator.GetFloat("ToungeLashCD") <= 0.5)
            {
                rb.MovePosition(Vector2.MoveTowards(transform.position, toad.GetPlayerPosition(), Time.deltaTime * speed));
                animator.SetBool("PlayerWithinRange", false);
            }
            else if(currDistance <= minDistance && animator.GetFloat("ToungeLashCD") <= 0.1)
            {
                //animator.SetBool("PlayerWithinRange", true);
                float chance = Random.Range(0, 100);
                Debug.Log(chance);
                if(chance < 50)
                {
                    animator.Play("Base Layer.TongueLash");
                }
                else
                {
                    animator.Play("Base Layer.JumpAttack");
                }
                
            }

            if (animator.GetFloat("ToungeLashCD") > 0.1)
            {

                animator.SetFloat("ToungeLashCD", animator.GetFloat("ToungeLashCD") - Time.deltaTime);
                return;
            }

            if (animator.transform.position.x > toad.GetPlayerPosition().x)
            {
                animator.transform.SetXScale(-1);
            }
            else
            {
                animator.transform.SetXScale(1);
            }


        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
