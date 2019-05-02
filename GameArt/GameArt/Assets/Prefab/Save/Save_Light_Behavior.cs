using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save_Light_Behavior : MonoBehaviour
{
    private float changeTime = 0;
    private float originalRange;
    private Light lt;
    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();
        originalRange = lt.range;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > changeTime)
        {
            changeTime = Random.Range(.2f, .8f) + Time.time;
            if (lt.range == originalRange)
            {
                lt.range = originalRange + .5f;
            }
            else
            {
                lt.range = originalRange;
            }
        }
    }
}
