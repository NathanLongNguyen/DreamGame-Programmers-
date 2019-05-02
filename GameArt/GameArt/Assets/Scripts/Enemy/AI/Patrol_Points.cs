using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_Points : MonoBehaviour
{
    private Enemy_Spawner spawner;
    public Transform[] pPoints;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (pPoints[0] == null)
        {
            Debug.Log("setting");
            spawner = GetComponentInParent<Enemy_Spawner>();
            for (int i = 0; i < spawner.waypoints.Length; i++)
            {
                pPoints[i] = spawner.waypoints[i];
            }
        }*/
    }
}
