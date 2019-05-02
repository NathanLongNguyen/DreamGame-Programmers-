using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_dam_move : MonoBehaviour
{

    public Transform[] points;
    public float changeRate;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = changeRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            int i = Random.Range(0, points.Length);
            gameObject.transform.position = points[i].transform.position;
            timer = changeRate;
        } 
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
