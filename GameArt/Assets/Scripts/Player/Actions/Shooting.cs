using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public Transform shotPos;
    float timer;
    public GameObject grappleHook;
    private PlayerController player;
    private Animator animator;

	// Use this for initialization
	void Start () {
        player = gameObject.GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {
<<<<<<< Updated upstream
            timer = attSpeed;
            //Shoot();
            animator.SetTrigger("RangeAtt");
=======
            Shoot();
>>>>>>> Stashed changes
        }
    }

    public void Shoot()
    {
        Instantiate(grappleHook, shotPos.position, Quaternion.identity);
    }
}

