using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodCharacterState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            // Set IsRunning to true
            animator.SetBool("IsRunning", true);
            //Debug.Log("IsRunning");
        }
        else
        {
            // Set IsRunning to false if no keys are pressed
            animator.SetBool("IsRunning", false);
            //Debug.Log("IsNotRunning");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("IsJumping", true);
            Debug.Log("IsJumping");
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
