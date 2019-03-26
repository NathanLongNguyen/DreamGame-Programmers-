using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed, jumpHeight; //That determine player's max speed
    Rigidbody rb; //Refer to the player's rigidbody
    public bool snappy; //Choose if we want a snappy vs fluid type movement (testing purposes)
    bool facingRight; //See if player is facing right
    bool isGrounded = false; //Check to is grounded
    Collider[] groundCollision;
    float groundC_rad;
    public LayerMask whatIsGround;
    public Transform groundCheckObj;
    public Text winText;
    private int maxJump = 2;
    int currJump;
<<<<<<< Updated upstream
    private Animator animator;
=======
    public bool grappleConnection = false;
    private float swingSpeed = 5f;
    private float angleR = 3.927f;
    private float angleL = 3.927f;
    private bool resetVelocity = false;

>>>>>>> Stashed changes

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        facingRight = true;
        //winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(isGrounded);
        Movement();
<<<<<<< Updated upstream

=======
        if (grappleConnection)
        {
            Swing();
        }
        else
        {
            angleR = 3.927f;
            angleL = 3.927f;
            rb.useGravity = true;
            resetVelocity = false;
        }
>>>>>>> Stashed changes
    }

    // Use FixedUpdate for physics based function
    void FixedUpdate()
    {
        
    }

    void Movement()
    {
        moveHorizontal();
        groundCheck();
        Jump();

    }

    //fucntion for moving horizontally
    void moveHorizontal()
    {
        float move;
        
        //See which type of movement we want
        if (!snappy)
        {
            move = Input.GetAxis("Horizontal");
            animator.SetFloat("speed", Mathf.Abs(move));
        }
        else
        {
            move = Input.GetAxisRaw("Horizontal");
            animator.SetFloat("speed", Mathf.Abs(move));
        }

        //move by changing the velocity of the rigidbody
        rb.velocity = new Vector3(move * speed, rb.velocity.y, 0);

        //Check to see if we need to flip the character
        if(move > 0 && !facingRight)
        {
            Flip();
        } else if (move < 0 && facingRight)
        {
            Flip();
        }
    }
    
    //function for flipping
    void Flip()
    {
        facingRight = !facingRight; //switch true to false or false to true
        Quaternion rot = transform.localRotation; //grabbing the z value of the character
        rot.y *= -1; //flip the object
        transform.localRotation = rot; //update the z of the character's scaling
    }

    //function for checking if the player is grounded
    void groundCheck()
    {
        
        groundCollision = Physics.OverlapSphere(groundCheckObj.position, groundC_rad, whatIsGround);
        if(groundCollision.Length> 0)
        {
            isGrounded = true;
            currJump = 0;
            animator.SetBool("isJumping", false);
        } else
        {
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }
    }



    //function for jumping 
    void Jump()
    {
        if(Input.GetButtonDown("Jump")  && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(Vector3.up *jumpHeight, 0);
            currJump++;
            
        }


    }

    void Swing()
    {
        if (!resetVelocity)
        {
            rb.velocity = Vector3.zero;
            resetVelocity = true;
        }
        GameObject grappleHook = GameObject.Find("grappleHook(Clone)");
        Vector3 centerPoint = grappleHook.transform.position;
        float distance = Vector3.Distance(grappleHook.transform.position, transform.position);
        //angle += swingSpeed * Time.deltaTime;
        var offset = Vector3.zero;
        if (grappleHook.GetComponent<grappleHook>().shootRight)
        {
            angleR += swingSpeed * Time.deltaTime;
            offset = new Vector3(Mathf.Cos(angleR), Mathf.Sin(angleR), 0) * distance;
        }
        else
        {
            angleL += swingSpeed * Time.deltaTime;
            offset = new Vector3(-Mathf.Cos(angleL), Mathf.Sin(angleL), 0) * distance;
        }
        rb.useGravity = false;
        rb.MovePosition(transform.position + (offset + centerPoint) * Time.deltaTime);
        //transform.position = centerPoint + offset;
    }

    public bool giveDir()
    {
        if (facingRight)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //Destroy the gameObject when collide
            Destroy(other.gameObject);
            //Can alternatively set to inactive instead:
            //other.gameObject.SetActive(false);
        }

        /*if (other.gameObject.CompareTag("EndTrigger"))
        {
            winText.text = "Level end!";
        }*/
    }

}

