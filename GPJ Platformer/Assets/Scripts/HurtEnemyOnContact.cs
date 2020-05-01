using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyOnContact : MonoBehaviour
{
    public int damageToGive;
    public float bounceOnEnemy;
    private Rigidbody2D myRb;

    void Start ()
    {
        myRb = transform.parent.GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthManager>().GiveDamage(damageToGive);
            myRb.velocity = new Vector2(myRb.velocity.x, bounceOnEnemy);
        }    
    }
}
