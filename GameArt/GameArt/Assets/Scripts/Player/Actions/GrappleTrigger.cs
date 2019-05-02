using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleTrigger : MonoBehaviour
{
    private Renderer rend;
    public string grappleType = "Hookshot";
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        rend.material.SetColor("_Color", Color.green);
        if (other.tag == "Player" && grappleType == "Hookshot")
        {
            other.GetComponent<ShootGrapple>().canHookshot = true;
        }
        else if (other.tag == "Player" && grappleType == "Grapple")
        {
            other.GetComponent<ShootGrapple>().canGrapple = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        rend.material.SetColor("_Color", Color.red);
        other.GetComponent<ShootGrapple>().canGrapple = false;
        other.GetComponent<ShootGrapple>().canHookshot = false;
    }
}
