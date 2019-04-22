using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGrapple : MonoBehaviour
{
    
    public Transform shotPos;
    private Vector3 offset;
    public GameObject grappleHook;
    public Transform originalOrientation;
    public Vector3 forceL, forceR;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0f, 1.4f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z") && GameObject.Find("grappleHook(Clone)") == null)
        {
            ShootG();
            //Destroy(GameObject.Find("grappleHook(Clone)"), 2f);
        }
        else if (Input.GetKeyDown("z") && GameObject.Find("grappleHook(Clone)") != null)
        {
            GetComponent<PlayerController>().rb.useGravity = true;
            GameObject.Find("Player").transform.rotation = Quaternion.identity;
            if (GameObject.Find("grappleHook(Clone)").GetComponent<grappleHook>().shootRight)
            {
                GameObject.Find("Player").transform.localRotation = Quaternion.Euler(0, 90, 0);
                GetComponent<PlayerController>().rb.AddForce(forceR);
            }
            else
            {
                GameObject.Find("Player").transform.localRotation = Quaternion.Euler(0, -90, 0);
                GetComponent<PlayerController>().rb.AddForce(forceL);
            }
            Destroy(GameObject.Find("grappleHook(Clone)"));
            GameObject.Find("Player").GetComponent<PlayerController>().grappleConnection = false;
            //GameObject.Find("Player").transform.rotation = originalOrientation.rotation;
        }
    }

    void ShootG()
    {
        Instantiate(grappleHook, shotPos.position + offset, Quaternion.identity);
    }
}
