using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    public GameObject Save_Light;
    public Vector3 offset = new Vector3(0f, .3f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.white);
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
            checkpointManager.GetComponent<CheckpointManager>().setLocation = GameObject.Find("Player").transform.position;
            checkpointManager.GetComponent<CheckpointManager>().checkpointScene = SceneManager.GetActiveScene();
            checkpointManager.GetComponent<CheckpointManager>().checkpointSaved = true;
            if (GameObject.Find("Save_Light(Clone)") == null)
            {
                Instantiate(Save_Light, transform.position + offset, Quaternion.identity);
            }
            //rend.material.SetColor("_Color", Color.yellow);
        }
    }
}
