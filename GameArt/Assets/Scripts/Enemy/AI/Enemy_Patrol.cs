using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Patrol : NPCBaseFSM
{





    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //agent.Resume();
        base.OnStateEnter(animator, stateInfo, layerIndex);

        GotoNextPoint();
    }

    public void GotoNextPoint()
    {
       
        // Set the agent to go to the currently selected destination.
        agent.destination = points.pPoints[destPoint].position;

        


    }

    public void SetNextPoint()
    {
        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.pPoints.Length;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GotoNextPoint();
        if (!agent.pathPending && agent.remainingDistance < 0.4f)
        {
            SetNextPoint();
            agent.Stop();
            animator.SetBool("Waiting", true);
        }
        if(health.curHealth <= 0)
        {
            agent.Stop();
            animator.SetTrigger("Death");
            health.Death();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    /*void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.

        agent.destination = points[destPoint].position;


        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }
    */
}
