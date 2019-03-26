using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiding : MonoBehaviour
{
    private GameObject player;
    private PlayerController playCon;
    bool isHiding;

    // Start is called before the first frame update
    void Start()
    {
        
        isHiding = true;
        player = GameObject.FindGameObjectWithTag("Player");
        playCon = player.GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playCon.canHide)
        {
            hide();
        }
        

    }

    void hide()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            isHiding = !isHiding;
            player.SetActive(isHiding);
    
            
        }

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
