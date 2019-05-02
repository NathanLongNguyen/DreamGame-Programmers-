using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannotGo : MonoBehaviour
{
    private Animator animator;
    private Enemy_Sight sight;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sight = GetComponentInChildren<Enemy_Sight>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "CannotPass" || other.tag == "Ground")
        {
            animator.SetBool("PlayerDetected", false);
            sight.timer = 0;
        }
    }
}
