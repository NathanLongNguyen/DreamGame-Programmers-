using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sight : MonoBehaviour {

    private Enemy_shooting shooting;
    private Animator animator;
    [SerializeField]
    float sightThershold;
    bool sighted;

    [SerializeField]
    float timer;

    // Use this for initialization
    void Start () {
        shooting = GetComponentInParent<Enemy_shooting>();
        animator = GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!sighted)
        {
            if (timer <=  0)
            {
                animator.SetBool("PlayerDetected", false);
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("PlayerDetected", true);
            //Debug.Log("Spotted");
            sighted = true;
            timer = sightThershold;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            sighted = false;

        }
    }
}
