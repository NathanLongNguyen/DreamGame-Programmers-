using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    bool isOpenning;
    public GameObject Door;

    // Start is called before the first frame update
    void Start()
    {
        isOpenning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpenning)
        {
            Door.transform.Translate(Vector3.up * Time.deltaTime * 5);
        }
        if (Door.transform.position.y > 5.88f)
        {
            isOpenning = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Action"))
            {
                isOpenning = true;
                Debug.Log("Openning Door");
            }
        }
    }
}
