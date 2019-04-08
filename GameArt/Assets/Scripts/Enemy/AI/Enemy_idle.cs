using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_idle : Enemy_Patrol
{

    public float waitTime;
    float timer;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        timer = waitTime;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            agent.Resume();
            Debug.Log("To Patrol");
            animator.SetBool("Waiting", false);       
        }
        else
        {
            timer -= Time.deltaTime;
        }
        if (sight.sighted)
        { 
            agent.Resume();
            Debug.Log("Chasing");
            animator.SetBool("Waiting", false);
        }
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


}
