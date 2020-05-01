using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileCtrl : MonoBehaviour
{
    public float speed;
    PlayerCtrl player;
    //public GameObject deathFX;
    public GameObject hitFX;
    public int pointsForKill;
    public float rotationSpeed;
    public int damageToGive;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerCtrl>();

        if (player.transform.localScale.x < 0)
        {
            speed = -speed	;
            rotationSpeed = -rotationSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.y);    
        GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Enemy")
        {
            // Instantiate(deathFX, other.transform.position, other.transform.rotation);
            // Destroy(other.gameObject);
            // ScoreManager.AddPoints(pointsForKill);
            other.GetComponent<EnemyHealthManager>().GiveDamage(damageToGive);
        }

        if (other.tag == "Boss")
        {
            other.GetComponent<BossHealthManager>().GiveDamage(damageToGive);
        }

        Instantiate(hitFX, other.transform.position, other.transform.rotation);
        Destroy(gameObject);    
    }
}
