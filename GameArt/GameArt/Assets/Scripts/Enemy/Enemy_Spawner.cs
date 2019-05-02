using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{

    public Transform spawn1, spawn2;
    public DetectionManager DM;
    //public Transform[] waypoints;
    public GameObject Shadows;
    public float spawnRate;
    [SerializeField]
    float timer;

    

    // Start is called before the first frame update
    void Start()
    {
        timer = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (!DM.isHidden)
        {
            if(timer <= 0)
            {
                Instantiate(Shadows, spawn1.position, spawn1.rotation);
                timer = spawnRate;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
        else
        {
            timer = spawnRate;
        }

    }
}
