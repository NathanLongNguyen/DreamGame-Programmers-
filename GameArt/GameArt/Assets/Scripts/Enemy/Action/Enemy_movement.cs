using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Enemy_movement : MonoBehaviour {

    public Transform[] points;
    private int destPoint = 0;
    public float speed;

    private Melee_enemy_Sight sight;

    void Start()
    {
        
        sight = GetComponentInChildren<Melee_enemy_Sight>();


    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[destPoint].position, speed* Time.deltaTime);

        if(Vector3.Distance(transform.position, points[destPoint].position) < 0.25f)
        {

        }
    }

    

}
