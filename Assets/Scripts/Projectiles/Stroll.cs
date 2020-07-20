using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stroll : StateMachineBehaviour
{
    public Transform Character;
    Vector3 RightMax;
    Vector3 LeftMin;
    public float speed;
    Vector3 CurrPosition;

    int Direction;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!Character)
        {
            Character = animator.GetComponent<Transform>();
        }

        float XMax = Random.Range(Character.position.x + 3, Character.position.x + 6);
        float XMin = Random.Range(Character.position.x - 6, Character.position.x - 3);
        RightMax = new Vector3(XMax, Character.position.y, Character.position.z);
        LeftMin = new Vector3(XMin, Character.position.y, Character.position.z);

        Debug.Log("Right: " + RightMax);
        Debug.Log("Left: " + LeftMin);

        Direction = 1;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CurrPosition = Character.transform.position;
        CurrPosition.x += Direction * speed * Time.deltaTime;

        if(Character.transform.position.x > RightMax.x && Direction == 1)
        {
            Direction = -1;
            Vector3 lookRight = Character.transform.localScale;
            lookRight.x *= -1;
            Character.transform.localScale = lookRight;
        }else if(Character.transform.position.x < LeftMin.x && Direction == -1)
        {
            Direction = 1;
            Vector3 lookLeft = Character.transform.localScale;
            lookLeft.x *= -1;
            Character.transform.localScale = lookLeft;
        }

        Character.transform.position = CurrPosition;

        RaycastHit2D hit = Physics2D.Raycast(this.CurrPosition, Vector2.right * Direction * 4);

        if (hit.collider)
        {

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }


}
