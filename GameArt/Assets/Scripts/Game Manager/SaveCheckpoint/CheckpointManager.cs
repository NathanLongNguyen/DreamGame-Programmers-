using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointManager : MonoBehaviour
{
    public bool checkpointSaved = false;
    public Scene checkpointScene;
    public Vector3 checkpointLocation;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player(Cube)");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash) && player != null && checkpointSaved)
        {
            //Destroy(player);
            //Insert code for loading scene first, if scene is different
            var clone = Instantiate(player, checkpointLocation, player.transform.rotation);
            clone.transform.localScale = new Vector3(1, 1, 1);
            clone.name = "Player(Cube)";
            Destroy(player);
            player = clone;
        }
    }
}
