using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone_chase : StateMachineBehaviour
{
    [SerializeField]
    private GameObject NPC;
    public float speed;
    public float distance;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Rigidbody rb;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        NPC = animator.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        rb = NPC.GetComponent<Rigidbody>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Vector3 PlayerPosition = player.transform.position;
       
        if (player.transform.position.x > NPC.transform.position.x)
        {
            PlayerPosition.x -= distance;
            NPC.transform.localRotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            PlayerPosition.x += distance;
            NPC.transform.localRotation = Quaternion.Euler(0, -90, 0);
        }

       

        NPC.transform.position = Vector3.MoveTowards(NPC.transform.position, PlayerPosition, speed * Time.deltaTime);
        
    }


}
