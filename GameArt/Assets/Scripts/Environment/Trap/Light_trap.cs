using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_trap : MonoBehaviour
{

    public GameObject light;
    public Rigidbody rb;
    float timer, trapTimer;
    public float flicker_rate, Fall_time;
    bool On_Off;

    // Start is called before the first frame update
    void Start()
    {
        trapTimer = Fall_time;
        timer = flicker_rate;
        On_Off = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(timer <= 0)
            {
                On_Off = !On_Off;
                light.SetActive(On_Off);
                timer = flicker_rate;
            }
            else if(trapTimer <= 0)
            {
                rb.useGravity = true;
            }
            else
            {
                trapTimer -= Time.deltaTime;
                timer -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            On_Off = true;
            light.SetActive(On_Off);
            trapTimer = Fall_time;
        }
    }

}
