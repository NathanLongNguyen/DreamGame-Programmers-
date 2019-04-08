using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating_Room : MonoBehaviour
{
    public float speed;
    public bool isRotating;

    // Start is called before the first frame update
    void Start()
    {
        isRotating = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (isRotating)
        {
            transform.Rotate(new Vector3(0,0,-1) * speed * Time.deltaTime);
            if(transform.localRotation.z%90 == 0)
            {
                isRotating = false;
            }
        }
    }
}
