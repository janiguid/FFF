using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeechProjectile : StateMachineBehaviour
{
    public Projectile myProjectile;
    private float initialCooldownTime;
    public float cooldown;
    Projectile Ball;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //initialCooldownTime = 5f;
        //cooldown = initialCooldownTime;
        //Ball = Instantiate(myProjectile, animator.transform);
        //Ball.direction = 2f * animator.GetComponent<Transform>().localScale.x;
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //cooldown -= Time.deltaTime;


        ////really buggy. temp code to test projectile spawning
        //if(cooldown < 0)
        //{
        //    cooldown = initialCooldownTime;
        //    Ball = Instantiate(myProjectile, animator.transform);
        //    Ball.direction = 2f * animator.GetComponent<Transform>().localScale.x;
        //}
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //cooldown = initialCooldownTime;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
