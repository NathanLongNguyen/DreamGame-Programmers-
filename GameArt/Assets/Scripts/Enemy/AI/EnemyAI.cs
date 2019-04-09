using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;

    public GameObject GetPlayer()

    {
        return player;
    }

    public LayerMask whatisEnemies;
    public Transform attackPos;
    public float attackRange;

    // Start is called before the first frame update
    void Start()
    {
        /*if(player = null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void give_Damage(int dam)
    {
        Collider[] enemiesToDam = Physics.OverlapSphere(attackPos.position, attackRange, whatisEnemies);
        for (int i = 0; i < enemiesToDam.Length; i++)
        {
            enemiesToDam[i].GetComponent<Health>().takeDamage(dam);
            //Debug.Log("stabbed");
        }
    }
}
