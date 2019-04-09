using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{

    public Transform spawn1, spawn2;
    public Transform[] waypoints;
    public GameObject Shadows;
    public bool spawn;

    int odds;
    

    // Start is called before the first frame update
    void Start()
    {
       
        spawn = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (spawn)
        { 
            odds = Random.Range(0, 100);
            if(odds > 50)
            {
                var newEnemy = Instantiate(Shadows, spawn1);
                newEnemy.transform.parent = gameObject.transform;
                spawn = false;
            }
            else
            {
                var newEnemy = Instantiate(Shadows, spawn1);
                newEnemy.transform.parent = gameObject.transform;
                spawn = false;
            }
        }
    }
}
