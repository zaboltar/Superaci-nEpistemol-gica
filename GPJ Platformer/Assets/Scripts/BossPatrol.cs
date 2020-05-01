using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatrol : MonoBehaviour
{
   public float moveSpeed;
   public bool moveRight;
    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;

    private bool notAtEdge;
    public Transform edgeCheck;

    private Rigidbody2D rbody;
    private float ySize;

    void Start ()
    {
        rbody = GetComponent<Rigidbody2D>();
        ySize = transform.localScale.y;
    }



   void Update()
   {

       hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
       notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

       if (hittingWall || !notAtEdge) moveRight = !moveRight;

       if (moveRight)
       {
           transform.localScale = new Vector3(-ySize,transform.localScale.y, transform.localScale.z);
           rbody.velocity = new Vector2 (moveSpeed, rbody.velocity.y);
       } else 
       {
           transform.localScale = new Vector3(ySize,transform.localScale.y, transform.localScale.z);
           rbody.velocity = new Vector2 (-moveSpeed, rbody.velocity.y);
       }
   }

}
