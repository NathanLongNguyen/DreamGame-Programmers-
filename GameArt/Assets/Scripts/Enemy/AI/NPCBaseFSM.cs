using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class NPCBaseFSM :StateMachineBehaviour
{
    public GameObject NPC;
    public GameObject player;
    public NavMeshAgent agent;
    public Patrol_Points points;
    public Health health;
    public int destPoint;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        player = NPC.GetComponent<EnemyAI>().GetPlayer();
        agent = NPC.GetComponent<NavMeshAgent>();
        points = NPC.GetComponent<Patrol_Points>();
        health = NPC.GetComponent <Health>();
        animator.SetTrigger("Start");
        destPoint = 0;
    }
}
