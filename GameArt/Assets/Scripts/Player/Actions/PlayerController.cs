using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    // Movement and jumping
    public float speed, jumpHeight;         //That determine player's max speed
    public Rigidbody rb;                    //Refer to the player's rigidbody
    public bool snappy;                     //Choose if we want a snappy vs fluid type movement (testing purposes)
    bool facingRight;                       //See if player is facing right
    bool isGrounded = false;                //Check to is grounded
    Collider[] groundCollision;
    Collider[] WallCollision;               //Currently not being used
    float groundC_rad;
    public LayerMask whatIsGround;
    public Transform groundCheckObj;
    private int maxJump = 2;                //Currently not being used
    private int currJump;
    private int touched = 0;                //Used for boss checking boss room rotations

    private Animator animator;

    // Detection/Stealth
    public bool canHide;
    public bool crouching;
    public float ButtonCooler = 0.5f;
    public int ButtonCount = 0;


    // Grappling
    public bool grappleConnection = false;
    private float swingSpeed = 4f;
    public float angleR = 3.927f;
    public float angleL = 3.927f;
    private bool resetVelocity = false;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        facingRight = true;
        crouching = false;
        canHide = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (grappleConnection)
        {
            DisableCrouch();
            Swing();
            animator.SetBool("isGrappling", true);
        }
        else
        {
            Movement();
            angleR = 3.927f;
            angleL = 3.927f;
            rb.useGravity = true;
            resetVelocity = false;
            animator.SetBool("isGrappling", false);
        }
    }

    // Use FixedUpdate for physics based function
    void FixedUpdate()
    {
        
    }

    #region Movement functions
    // Basic movement function, checks crounching and jumping status
    void Movement()
    {
        moveHorizontal();
        groundCheck();
        Jump();
        Crouch();
    }

    void BossMovement()
    {
        BossMovementHelper();
        groundCheck();
        Jump();
        Crouch();
    }

    void BossMovementHelper()
    {
        if(touched == 0)
        {
            Vector3 bossMove = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            transform.position += bossMove * speed * Time.deltaTime;
        }
        else
        {
            Vector3 bossMove = new Vector3(0, 0, Input.GetAxis("Horizontal"));
            transform.position += bossMove * speed * Time.deltaTime;
        }
    }

    // Function for moving horizontally
    void moveHorizontal()
    {
        float move;

        //Dashing

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (ButtonCooler > 0 && ButtonCount == 1)
            {
                animator.SetBool("isDashing", true);
            }
            else
            {
                ButtonCooler = 0.5f;
                ButtonCount += 1;
            }
        }

        if (ButtonCooler > 0)
        {
            ButtonCooler -= 1 * Time.deltaTime;
        }
        else
        {
            ButtonCount = 0;
        }

        //No crouching and moving
        if (animator.GetFloat("speed") > 0f)
        {
            DisableCrouch();
        }
        
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
    
    // Function for flipping the player
    void Flip()
    {
        facingRight = !facingRight;                 //switch true to false or false to true
        Quaternion rot = transform.localRotation;   //grabbing local rotation of player
        rot.y *= -1;                                //flip the object (y axis)
        transform.localRotation = rot;              //update the rotation
    }

    // Function for checking if the player is grounded
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

    // Function for crouching
    void Crouch()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            bool crouchStatus = animator.GetBool("Ducking");
            animator.SetBool("Ducking", !crouchStatus);
            crouching = !crouchStatus;
        }
    }

    void DisableCrouch()
    {
        animator.SetBool("Ducking", false);
        crouching = false;
    }


    // Function for jumping 
    void Jump()
    {
        if (animator.GetBool("isJumping") && rb.velocity.y < 0)
        {
            float fallMultiplierFloat = 2.0f;
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplierFloat - 1) * Time.deltaTime;
        }
        if(Input.GetButtonDown("Jump")  && isGrounded)
        {
            DisableCrouch();
            isGrounded = false;
            rb.AddForce(Vector3.up *jumpHeight, 0);
            currJump++;
            
        }
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
    #endregion
    #region Grappling
    void Swing()
    {
        GameObject grappleHook = GameObject.Find("grappleHook(Clone)");
        Vector3 centerPoint = grappleHook.transform.position;
        float distance = Vector3.Distance(grappleHook.transform.position, transform.position);
        //angle += swingSpeed * Time.deltaTime;
        var offset = Vector3.zero;
        if (grappleHook.GetComponent<grappleHook>().shootRight)
        {
            //transform.eulerAngles = new Vector3(0, 90, 0);
            angleR += swingSpeed * (1.1f - (Mathf.Abs((angleR - 4.7f) / (4.7f - 3.5f)))) * Time.deltaTime;
            //angleR += swingSpeed * Time.deltaTime;
            offset = new Vector3(Mathf.Cos(angleR), Mathf.Sin(angleR), 0) * distance;
            //if (angleR > 4.7) Debug.Break();
            //transform.eulerAngles = new Vector3(0,90,angleR*(180/Mathf.PI));
            transform.LookAt(grappleHook.transform);
            //transform.rotation *= Quaternion.Euler(90, 0, 0);
            if (transform.position.x - grappleHook.transform.position.x < 0) transform.localRotation *= Quaternion.Euler(90, 0, 0);
            else transform.localRotation *= Quaternion.Euler(-90, -90, -90);
            GetComponent<ShootGrapple>().forceR = offset * angleR;
            if (angleR > 5.9 && transform.position.x - grappleHook.transform.position.x > 0)
            {
                //transform.eulerAngles = new Vector3(0, -90, 0);
                grappleHook.GetComponent<grappleHook>().shootRight = false;
                angleL = 3.5f;
                //Flip();
                transform.localRotation *= Quaternion.Euler(1, -1, 1);
                facingRight = !facingRight;
            }
        }
        else
        {
            //transform.eulerAngles = new Vector3(0, -90, 0);
            angleL += swingSpeed * (1.1f - (Mathf.Abs((angleL - 4.7f) / (4.7f - 3.5f)))) * Time.deltaTime;
            //angleL += swingSpeed * Time.deltaTime;
            offset = new Vector3(-Mathf.Cos(angleL), Mathf.Sin(angleL), 0) * distance;
            //transform.eulerAngles = new Vector3(0,90,-angleL * (180 / Mathf.PI));
            //Debug.Log(angleL);
            transform.LookAt(grappleHook.transform);
            //transform.rotation *= Quaternion.Euler(90, 0, 0);
            if (transform.position.x - grappleHook.transform.position.x > 0) transform.localRotation *= Quaternion.Euler(90, 0, 0);
            else transform.localRotation *= Quaternion.Euler(-90, -90, -90);
            GetComponent<ShootGrapple>().forceL = offset * angleL;
            if (angleL > 5.9 && transform.position.x - grappleHook.transform.position.x < 0)
            {
                //transform.eulerAngles = new Vector3(0, 90, 0);
                grappleHook.GetComponent<grappleHook>().shootRight = true;
                angleR = 3.5f;
                //Flip();
                transform.localRotation *= Quaternion.Euler(1, -1, 1);
                facingRight = !facingRight;
            }
        }
        rb.useGravity = false;
        //Debug.Log(centerPoint - transform.position);
        //rb.MovePosition(transform.position + (offset + centerPoint) * Time.deltaTime);
        rb.MovePosition(centerPoint + offset);
        //transform.position = centerPoint + offset;
        //rb.AddForce((centerPoint - transform.position) * swingSpeed);
        //rb.AddForce(centerPoint + offset);
    }
    #endregion

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //Destroy the gameObject when collide
            Destroy(other.gameObject);
            //Can alternatively set to inactive instead:
            //other.gameObject.SetActive(false);
        }
    }

}

