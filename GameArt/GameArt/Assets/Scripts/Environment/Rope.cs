using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Transform player;
    private Transform grappleHook;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //offset = new Vector3(.2f, 1.3f, 0f);
        offset = Vector3.zero;
        player = GameObject.Find("Melee_Knife").transform;
        grappleHook = GameObject.Find("grappleHook(Clone)").transform;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, player.position);
        lineRenderer.SetWidth(.1f, .1f);
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, player.position + offset);
        lineRenderer.SetPosition(1, grappleHook.position);
        if(GameObject.Find("grappleHook(Clone)") == null)
        {
            Destroy(gameObject);
        }
    }
}
