using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Renderer rend = GetComponent<Renderer>();
        GameObject checkpointManager = GameObject.Find("CheckpointManager");
        if (other.tag == "Player" && checkpointManager != null)
        {
            checkpointManager.GetComponent<CheckpointManager>().checkpointLocation = transform.position;
            checkpointManager.GetComponent<CheckpointManager>().checkpointScene = SceneManager.GetActiveScene();
            checkpointManager.GetComponent<CheckpointManager>().checkpointSaved = true;
            rend.material.SetColor("_Color", Color.yellow);
        }
    }
}
