using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCharacterState1 : StateMachineBehaviour
{
    private Animator _animator;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this._animator = animator;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Check if any of the relevant keys are pressed
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            // Set IsRunning to true
            animator.SetBool("IsRunning1", true);
            //Debug.Log("IsRunning");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("IsJumping1", true);

            Debug.Log("IsJumping1");
        }
        else
        {
            // Set IsRunning to false if no keys are pressed
            animator.SetBool("IsRunning1", false);
            animator.SetBool("IsJumping1", false);  
            //Debug.Log("IsNotRunning");
        }

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
