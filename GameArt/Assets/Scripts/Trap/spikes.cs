using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{
    private float timer;
    public float speed = 3f;
    public float upTime = 2f;
    public float downTime = 5f;
    private Vector3 initial;
    public Vector3 offset;
    public string status = "down";

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Do some damage to the player
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //DeleteMe
        GetComponent<Renderer>().material.color = Color.red;
        //DeleteMe
        timer = Time.time;
        initial = this.transform.position;
        if (offset == Vector3.zero)
        {
            offset = initial;
            offset += new Vector3(0f, 1f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        switch(status)
        {
            case "up":
                transform.position = Vector3.MoveTowards(transform.position, offset, step);
                if (timer <= Time.time)
                {
                    status = "down";
                    timer = Time.time + downTime;
                }
                break;
            case "down":
                transform.position = Vector3.MoveTowards(transform.position, initial, step);
                if (timer <= Time.time)
                {
                    status = "up";
                    timer = Time.time + upTime;
                }
                break;
            case "disabled":
                break;
            default:
                break;
        }
    }
}
