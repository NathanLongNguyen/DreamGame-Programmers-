using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_dam : MonoBehaviour
{
    public int damage;
    private Health health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            health = other.GetComponent<Health>();
            health.takeDamage(damage);
        }
    }
}
