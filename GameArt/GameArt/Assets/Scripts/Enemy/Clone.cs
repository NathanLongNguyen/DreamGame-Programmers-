using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    private Health health;
    private DetectionManager DM;

    // Start is called before the first frame update
    void Start()
    {
        DM = GameObject.FindGameObjectWithTag("DetectionManager").GetComponent<DetectionManager>();
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DM.isHidden)
        {
            health.Death();
        }
    }
}
