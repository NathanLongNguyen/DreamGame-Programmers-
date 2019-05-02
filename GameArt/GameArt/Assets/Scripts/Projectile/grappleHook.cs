using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grappleHook : MonoBehaviour
{
    public float timer;
    public float speed = 10;
    private bool contact = false;
    public bool shootRight;
    private Vector3 velocity;
    public Rigidbody rb;
    private PlayerController player;
    private bool setOrientation = false;
    public string grappleType;
    public GameObject rope;

    // Start is called before the first frame update
    void Start()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && !contact)
        {
            Destroy(gameObject);
        }
        if (GameObject.Find("Player").transform.eulerAngles.y == 90) shootRight = true;
        else shootRight = false;

        Instantiate(rope, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        if (shootRight)
        {
            velocity = new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, 0);
        }
        else
        {
            velocity = new Vector3(-speed * Time.deltaTime, speed * Time.deltaTime, 0);
        }
        pos += transform.rotation * velocity;
        transform.position = pos;

        timer -= Time.deltaTime;

        if (timer <= 0 && !contact)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grapple Surface"))
        {
            contact = true;
            speed = 0;
            //GameObject.Find("Player").GetComponent<PlayerController>().grappleConnection = true;
            if (setOrientation == false)
            {
                GameObject.Find("Player").GetComponent<ShootGrapple>().originalOrientation = GameObject.Find("Player").transform;
                setOrientation = true;
            }
            if (grappleType == "grapple")
            { GameObject.Find("Player").GetComponent<PlayerController>().grappleConnection = true; }
            else if (grappleType == "hookshot")
            { GameObject.Find("Player").GetComponent<PlayerController>().hookshotConnection = true; }

            //Destroy(gameObject, .5f);
        }
        else if (other.CompareTag("Player"))
        {
            //blank space, will change later
        }
        else if (!other.CompareTag("Grapple Surface"))
        {
            //play 'dink' sound
            contact = false;
            Destroy(gameObject);
        }
    }
}
