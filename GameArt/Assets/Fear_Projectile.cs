using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fear_Projectile : MonoBehaviour
{
    public float timer;
    public float speed;
    public Rigidbody rb;
    private PlayerController player;
    private Health E_Health;
    public int damage;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }

    }

    void FixedUpdate()
    {
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(speed * Time.deltaTime, 0, 0);
        pos += transform.rotation * velocity;

        transform.position = pos;
    }

    //Destroy on touch for now
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Ground"))
        {
            if (other.CompareTag("Player"))
            {
                E_Health = other.GetComponent<Health>();
                E_Health.takeDamage(damage);
            }
            Destroy(gameObject);
        }
    }


}
