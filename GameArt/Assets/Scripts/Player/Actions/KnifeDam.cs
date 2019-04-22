using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeDam : MonoBehaviour
{

    int damage;
    private Health health;

    // Start is called before the first frame update
    void Start()
    {
        damage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KnifeOn(int dam)
    {
        damage = dam;
    }

    public void KnifeOff()
    {
        damage = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            health = other.GetComponent<Health>();
            health.takeDamage(damage);
        }
    }

}
