using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform target;
    private float smoothing = 3f;
    public float z_offset, y_offset, x_offset;
    public string state;
    private float offset;
    private Vector3 cameraPos;
    private float timer = 2f;
    private float stateTimer;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("PlayerFollower").transform;
        offset = 10f;
        state = "state1";
        transform.position = new Vector3(target.position.x, target.position.y, target.position.z - offset);
        z_offset = transform.position.z - target.position.z;
        y_offset = 0;
        x_offset = 0;
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
        FlipCamera();
        transform.position = Vector3.Lerp(transform.position, cameraPos, smoothing * Time.deltaTime);
    }

    void FixedUpdate()
    {
        //transform.LookAt(target);
        //updateCameraPos();
        //Vector3 cameraPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        //Vector3 cameraPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        //transform.position = Vector3.MoveTowards(transform.position, cameraPos, smoothing * Time.deltaTime);
        /*
        if (isPlayerAlive(target) && state == "default")
        {
            Vector3 cameraPos = new Vector3(z_offset, target.position.y, target.position.x);
            transform.position = Vector3.Lerp(transform.position, cameraPos, smoothing * Time.deltaTime);
        }
        if (isPlayerAlive(target) && state == "state1")
        {
            Vector3 cameraPos = new Vector3(target.position.x, target.position.y, z_offset);
            transform.position = Vector3.Lerp(transform.position, cameraPos, smoothing * Time.deltaTime);
        }
        */
    }

    public void FlipCamera()
    {
        if (state == "state1")
            cameraPos = new Vector3(target.position.x, target.position.y, target.position.z - offset);
        if (state == "state2")
            cameraPos = new Vector3(target.position.x + offset, target.position.y, target.position.z);
        if (state == "state3")
            cameraPos = new Vector3(target.position.x, target.position.y, target.position.z + offset);
        if (state == "state4")
            cameraPos = new Vector3(target.position.x - offset, target.position.y, target.position.z);
    }

    public void updateState()
    {
        if (stateTimer > Time.time) return;
        switch (state)
        {
            case "state1":
                state = "state2";
                stateTimer = timer + Time.time;
                break;
            case "state2":
                state = "state3";
                stateTimer = timer + Time.time;
                break;
            case "state3":
                state = "state4";
                stateTimer = timer + Time.time;
                break;
            case "state4":
                state = "state1";
                stateTimer = timer + Time.time;
                break;
            default:
                state = "state1";
                stateTimer = timer + Time.time;
                break;
        }
    }

    bool isPlayerAlive(Transform player)
    {
        if (player != null) return true;
        else return false;
    }
}
