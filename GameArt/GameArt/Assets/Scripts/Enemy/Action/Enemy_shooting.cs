using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_shooting : MonoBehaviour {


    public Transform shotPos, shotPosL;
    public GameObject bulletPre;
    public float fireRate;
    float timer;
    bool canShoot;
    private Fear_Rot FR;

	// Use this for initialization
	void Start () {
        FR = GetComponent<Fear_Rot>();
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            canShoot = true;
        }
  
	}

    public void Shoot()
    {
        if (canShoot)
        {


            if (FR.facingRight)
            {
                Debug.Log("shoot right");
                Instantiate(bulletPre, shotPos.position, shotPos.rotation);
                timer = fireRate;
                canShoot = false;
            }
            else if (!FR.facingRight)
            {
                Debug.Log("shoot left");
                Instantiate(bulletPre, shotPosL.position, shotPosL.rotation);
                timer = fireRate;
                canShoot = false;
            }
        }
    }
}
