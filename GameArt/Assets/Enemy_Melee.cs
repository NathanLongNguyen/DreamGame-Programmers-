using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Melee : MonoBehaviour
{
    [SerializeField]
    float timer;

    Animator animator;
    NavMeshAgent agent;

    public float AttackCD;

    private Enemy_Sight sight;
    private Health pHealth;

    private GameObject NPC;


    // Start is called before the first frame update
    void Start()
    {
        sight = GetComponentInParent<Enemy_Sight>();
        agent = GetComponentInParent<NavMeshAgent>();
        pHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        animator = GetComponentInParent<Animator>();
        timer = AttackCD;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        /*if (other.CompareTag("Player"))
        {
            if(timer <= 0)
            {
                agent.Stop();
                animator.SetTrigger("Melee");
                Debug.Log("Attacking");
                timer = AttackCD;
                agent.Resume();
            }
        }*/
        switch (other.tag)
        {
            case "Player":
                if (timer <= 0)
                {
                    agent.Stop();
                    animator.SetTrigger("Melee");
                    Debug.Log("Attacking");
                    timer = AttackCD;
                    agent.Resume();
                }
                break;
            case "Ground":
                animator.SetBool("PlayerDetected", false);
                sight.timer = 0;
                break;
        }
    }


}
