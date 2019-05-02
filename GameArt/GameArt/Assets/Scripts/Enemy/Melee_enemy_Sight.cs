using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Melee_enemy_Sight : MonoBehaviour
{
    [SerializeField]
    float sightThershold;

    float timer;
    public bool playerSighted;

    // Start is called before the first frame update
    void Start()
    {
        timer = sightThershold;
        playerSighted = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerSighted);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                
                timer = 0;
                playerSighted = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            playerSighted = false;

        }
    }
}
