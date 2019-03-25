using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGrapple : MonoBehaviour
{
    
    public Transform shotPos;
    public GameObject grappleHook;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z") && GameObject.Find("grappleHook(Clone)") == null)
        {
            Shoot();
            //Destroy(GameObject.Find("grappleHook(Clone)"), 2f);
        }
        else if (Input.GetKeyDown("z") && GameObject.Find("grappleHook(Clone)"))
        {
            Destroy(GameObject.Find("grappleHook(Clone)"));
            GameObject.Find("Player(Cube)").GetComponent<PlayerController>().grappleConnection = false;
        }
    }

    void Shoot()
    {
        Instantiate(grappleHook, shotPos.position, Quaternion.identity);
    }
}
