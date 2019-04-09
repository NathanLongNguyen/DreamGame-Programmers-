using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiding : MonoBehaviour
{
    private GameObject player;
    private PlayerController playCon;
    private Rigidbody playRB;
    private BoxCollider playBC;
    bool isHiding;

    // Start is called before the first frame update
    void Start()
    {
        
        isHiding = true;
        player = GameObject.FindGameObjectWithTag("Player");
        playCon = player.GetComponent<PlayerController>();
        playRB = player.GetComponent<Rigidbody>();
        playBC = player.GetComponent<BoxCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playCon.canHide && player.GetComponent<Animator>().GetBool("Ducking"))
        {
            hide();
        }
        else
        {
            UnFreezePlayer();
            changeOpacity(255);
        }
        
    }

    void FreezePlayer()
    {
        playRB.constraints = RigidbodyConstraints.FreezeAll;
        playBC.enabled = false;
    }

    void UnFreezePlayer()
    {
        playBC.enabled = true;
        playRB.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
    }

    void hide()
    {
       FreezePlayer();
       changeOpacity(100);
    }

    void changeOpacity(byte num)
    {
        gameObject.GetComponent<Renderer>().material.color = new Color32(47, 140, 52, num);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playCon.canHide = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playCon.canHide = false;
        }
    }


}
