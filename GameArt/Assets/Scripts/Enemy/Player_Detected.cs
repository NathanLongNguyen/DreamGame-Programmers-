using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Detected : MonoBehaviour
{

    public GameObject Ex_Point;
    public bool sighted;

    // Start is called before the first frame update
    void Start()
    {
        //sighted = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sighted)
            Ex_Point.SetActive(true);
        else if (!sighted)
            Ex_Point.SetActive(false);
    }
}
