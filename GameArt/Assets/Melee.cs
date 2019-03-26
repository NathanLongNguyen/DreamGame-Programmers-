using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{

   
    private Health health;
    Animator animator;
    private KnifeDam knife;

    public LayerMask whatisEnemies;
    public Transform attackPos;
    public float attackRange;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        knife = GetComponentInChildren<KnifeDam>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            animator.SetTrigger("Melee");
        }
    }



    void DealDamage(int damage)
    {

        Audio.PlaySound("KnifeMelee");
        Collider[] enemiesToDam = Physics.OverlapSphere(attackPos.position, attackRange, whatisEnemies);
        for (int i =0; i < enemiesToDam.Length; i++)
        {
            enemiesToDam[i].GetComponent<Health>().takeDamage(damage);
            //Debug.Log("stabbed");
        }
    }

}
