using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Damage : MonoBehaviour
{
    private Health bossHealth;

    // Start is called before the first frame update
    void Start()
    {
        bossHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Knife")
        {

        }
    }
}
