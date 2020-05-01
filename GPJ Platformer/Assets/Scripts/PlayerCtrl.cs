using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    
    public float moveSpeed;
    private float moveVelocity;
    public float jumpHeight;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    private bool doubleJumped;
    private Animator anim; 

    public Transform firePoint;
    public GameObject projectile;

    public float shootDelay;
    private float shootDelayCounter;

    private Rigidbody2D myRb;
    public float knockBack;
    public float knockBackCount;
    public float knockBackLenght;
    public bool knockFromRight;
    public bool onLadder;
    public float climbSpeed;
    private float climbVelocity;
    private float gravityStore;




    void Start()
    {
        anim = GetComponent<Animator>();
        myRb = GetComponent<Rigidbody2D>();
        gravityStore = myRb.gravityScale;
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

    }

    
    void Update()
    {
        if (grounded) doubleJumped = false;

        anim.SetBool("Grounded", grounded);
        
//#if UNITY_STANDALONE || UNITY_WEBPLAYER
        if (Input.GetButtonDown("Jump") && grounded)
        {
            Jump();

        }

        if (Input.GetButtonDown("Jump") && !doubleJumped && !grounded)
        {
            Jump();
            doubleJumped = true;

        }

        //moveVelocity = 0f;
/*
        if (Input.GetKey(KeyCode.D))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = moveSpeed;

        }

         if (Input.GetKey(KeyCode.A))
        {
           // GetComponent<Rigidbody2D>().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
           moveVelocity = -moveSpeed;

        }*/

       
        //moveVelocity = moveSpeed *  Input.GetAxisRaw("Horizontal");
        Move(Input.GetAxisRaw("Horizontal"));

//#endif

        if (knockBackCount <= 0)
        {
            myRb.velocity = new Vector2 (moveVelocity, myRb.velocity.y );
        } else
        {
            if (knockFromRight)
            {
                myRb.velocity = new Vector2 (-knockBack, knockBack);
            }
             if (!knockFromRight)
            {
                myRb.velocity = new Vector2 (knockBack, knockBack);
            }
            knockBackCount -= Time.deltaTime;
        }

        

        anim.SetFloat("Speed", Mathf.Abs(myRb.velocity.x));

        if (myRb.velocity.x > 0)
        {
            transform.localScale = new Vector3 (1f, 1f, 1f);
        }    else if (myRb.velocity.x < 0)
        {
            transform.localScale = new Vector3 (-1f, 1f, 1f);
        }

//#if UNITY_STANDALONE || UNITY_WEBPLAYER

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("Shoot", true);
            //Instantiate(projectile, firePoint.position, firePoint.rotation);
            ShootSun();
            shootDelayCounter = shootDelay;
        }

        if (Input.GetButton("Fire1"))
        {
            shootDelayCounter -= Time.deltaTime;

            if (shootDelayCounter <= 0)
            {
                shootDelayCounter = shootDelay;
               // Instantiate(projectile, firePoint.position, firePoint.rotation);
               ShootSun();
            }
        }

        if (anim.GetBool("Kick")) // attack on Q
        {
            //anim.SetBool("Kick", false);
            ResetKick();
        }

        if (Input.GetButtonDown("Fire2"))
        {
           // anim.SetBool("Kick", true);
           Kick();

        }
//#endif

        if (onLadder)
        {
            myRb.gravityScale = 0f;
            climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");

            myRb.velocity = new Vector2 (myRb.velocity.x, climbVelocity);
        }

        if (!onLadder)
        {
            myRb.gravityScale = gravityStore;
        }

    }

    public void FinishShoot()
    {
        anim.SetBool("Shoot", false);
    }

    public void Move (float moveInput)
    {
        moveVelocity = moveSpeed *  moveInput;
    }

    public void ShootSun()
    {
        Instantiate(projectile, firePoint.position, firePoint.rotation);
    }

    public void Kick()
    {
        anim.SetBool("Kick", true);
    }

    public void ResetKick()
    {
        anim.SetBool("Kick", false);
    }

    public void Jump()
    {
        

        if (grounded)
        {
            //Jump();
            myRb.velocity = new Vector2 (myRb.velocity.x, jumpHeight);
        }

        if ( !doubleJumped && !grounded)
        {
            //Jump();
            myRb.velocity = new Vector2 (myRb.velocity.x, jumpHeight);
            doubleJumped = true;

        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
}
