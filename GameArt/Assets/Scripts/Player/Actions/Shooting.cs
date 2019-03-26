using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public float attSpeed;
    public Transform shotPos, shotPosR;
    float timer;
    public GameObject bullet;
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

        if (Input.GetButton("Fire1") && timer <= 0)
        {
            timer = attSpeed;
            //Shoot();
            animator.SetTrigger("RangeAtt");
        }
    }

    public void Shoot()
    {
        Audio.PlaySound("KnifeThrow");
        if (player.giveDir())
        {

            Instantiate(bullet, shotPos.position, shotPos.rotation);
        }
        else if (!player.giveDir())
        {
            //Debug.Log("shoot left");
            Instantiate(bullet, shotPosR.position, shotPosR.rotation);
        }
    }
}

