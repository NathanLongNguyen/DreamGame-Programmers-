using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone_melee : MonoBehaviour
{
    private Animator animator;
    public float attackRate;
    float timer;
    bool canAttack;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        animator = GetComponentInParent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            canAttack = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (canAttack)
            {
                animator.SetTrigger("Melee");
                canAttack = false;
                timer = attackRate;
            }
        }
    }
}
