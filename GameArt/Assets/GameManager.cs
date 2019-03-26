using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject playerDead;
    public GameObject player;
    public Transform playerSpawn;
    //bool isPlayerDead;

    // Start is called before the first frame update
    void Start()
    {
        //isPlayerDead = false;
        Instantiate(player, playerSpawn.position, playerSpawn.rotation);
        playerDead = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(playerDead == null)
        {
            Instantiate(player, playerSpawn.position, playerSpawn.rotation);
            playerDead = GameObject.FindGameObjectWithTag("Player");
        }
    }
}
