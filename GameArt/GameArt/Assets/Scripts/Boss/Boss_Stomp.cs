using System.Collections;
//using System;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Stomp : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject objects;
    int odds;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void stomp()
    {
        Random random = new Random();
        odds = Random.Range(0, spawnPoint.Length);
        Debug.Log(odds);

        for(int i =0; i < spawnPoint.Length; i++)
        {
            Instantiate(objects, spawnPoint[i].position, spawnPoint[i].rotation);
        }
    }


}
