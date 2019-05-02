using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    private GameObject player;
    private float smoothing;
    // Start is called before the first frame update
    void Start()
    {
        smoothing = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        transform.position = Vector3.Lerp(transform.position, player.transform.position, smoothing * Time.deltaTime);
    }
}
