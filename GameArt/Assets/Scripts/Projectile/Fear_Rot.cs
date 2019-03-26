using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fear_Rot : MonoBehaviour
{

    float timer;
    public float flipTimer;
    public bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        timer = flipTimer;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(facingRight);
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            flip();
            timer = flipTimer;
        }
    }

    void flip()
    {
        if (facingRight)
            facingRight = false;
        else if (!facingRight)
            facingRight = true;
        Quaternion rot = transform.localRotation; //grabbing the z value of the character
        rot.y *= -1; //flip the object
        transform.localRotation = rot; //update the z of the character's scaling
    }
}
