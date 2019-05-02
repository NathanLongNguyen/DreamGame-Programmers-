using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Chasing : NPCBaseFSM
{

    public float distance;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Waiting", false);
        Vector3 PlayerPosition = player.transform.position;

        if (player.transform.position.x > NPC.transform.position.x)
        {
            PlayerPosition.x -= distance;
        }
        else
        {
            PlayerPosition.x += distance;
        }

        agent.destination = PlayerPosition;

        if (health.curHealth <= 0)
        {
            agent.Stop();
            animator.SetTrigger("Death");
            health.Death();
        }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.Stop();
        agent.ResetPath();
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
