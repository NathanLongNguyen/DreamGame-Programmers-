using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sight : MonoBehaviour {

    private Enemy_shooting shooting;
    private Player_Detected detected;
    private Animator playerAnimator;
    private PlayerController playerController;
    public DetectionManager DM;

    private Animator animator;
    [SerializeField]
    public float sightThershold;
    public bool sighted;


    [SerializeField]
    public float timer;

    // Use this for initialization
    void Start () {
        //DM = GameObject.FindGameObjectWithTag("Player").GetComponent<DetectionManager>();
        detected = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Detected>();
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        shooting = GetComponentInParent<Enemy_shooting>();
        animator = GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if ((playerAnimator.GetBool("Ducking") && playerController.canHide))
        {
            animator.SetBool("PlayerDetected", false);
            sighted = false;
        }

        if (sighted)
        {
            if (timer <= 0)
            {
                //Debug.Log("Reset this ");
                animator.SetBool("PlayerDetected", false);
                sighted = false;
                detected.sighted = false;
                DM.isHidden = true;
            }
            else
            {
                animator.SetBool("PlayerDetected", true);
                timer -= Time.deltaTime;
                detected.sighted = true;
            }
        }
        else
            timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Debug.Log("Reset this ");
            animator.SetBool("PlayerDetected", false);
            sighted = false;
            detected.sighted = false;
            DM.isHidden = true;
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
            DM.isHidden = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            //sighted = false;

        }
    }
}
