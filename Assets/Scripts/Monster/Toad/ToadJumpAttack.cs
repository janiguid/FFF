using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToadJumpAttack : StateMachineBehaviour
{
    [SerializeField] float height;
    [SerializeField] float maxJumps;
    [SerializeField] float timeBetweenJumps;
    private Rigidbody2D rb;
    private ToadManager manager;
    private float initialVel;
    private float displacement;

    private float timer;
    [SerializeField] private int jumpsDone;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.gameObject.GetComponent<Rigidbody2D>();
        manager = animator.gameObject.GetComponent<ToadManager>();

        //vertical velocity
         initialVel = Mathf.Sqrt(height*2*rb.gravityScale);
        Debug.Log(initialVel);
        //horizontal velocity
        float playerLoc = FindObjectOfType<PlayerManager>().transform.position.x;
        displacement = 0;
        displacement = playerLoc - animator.transform.position.x;
        displacement *= (1 / 3) + (1 % 3);

        Jump(animator);
        if (maxJumps == 0) maxJumps = 3;
        if (timeBetweenJumps == 0) timeBetweenJumps = 2;
        timer = 0;
        
    }

   // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (animator.transform.position.x > manager.GetPlayerPosition().x)
        {
            animator.transform.SetXScale(-1);
        }
        else
        {
            animator.transform.SetXScale(1);
        }


        //if (timer > 0)
        //{
        //    timer -= Time.deltaTime;

        //}
        //else
        //{
        //    ++jumpsDone;
        //    timer = timeBetweenJumps;
        //    Jump(animator);
            
        //}

        //if (jumpsDone == maxJumps && timer < 0.1f)
        //{
        //    animator.SetFloat("ToungeLashCD", 3);
        //    animator.Play("Base Layer.LookForPlayer");
        //    jumpsDone = 0;
        //}
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //jumpsDone = 0;
        animator.SetFloat("ToungeLashCD", 3);
    }

    void Jump(Animator animator)
    {
        float playerLoc = FindObjectOfType<PlayerManager>().transform.position.x;
        displacement = 0;
        displacement = playerLoc - animator.transform.position.x;
        displacement *= (1 / 3) + (1 % 3);
        rb.velocity = new Vector2(displacement, initialVel);
    }

}
