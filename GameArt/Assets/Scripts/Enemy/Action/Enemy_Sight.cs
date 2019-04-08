using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sight : MonoBehaviour {

    private Enemy_shooting shooting;
    private Animator animator;
    [SerializeField]
    public float sightThershold;
    public bool sighted;

    [SerializeField]
    public float timer;

    // Use this for initialization
    void Start () {
        shooting = GetComponentInParent<Enemy_shooting>();
        animator = GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {


        if (sighted)
        {
            if (timer <=  0)
            {
                animator.SetBool("PlayerDetected", false);
                sighted = false;
            }
            else
            {
                animator.SetBool("PlayerDetected", true);
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
