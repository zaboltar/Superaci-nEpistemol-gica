﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBolt : MonoBehaviour
{
  public float speed;
    PlayerCtrl player;
    
    public GameObject hitFX;
    
    public float rotationSpeed;
    public int damageToGive;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerCtrl>();

        if (player.transform.position.x < transform.position.x)
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

        if (other.name == "Player")
        {
            HealthManager.HurtPlayer(damageToGive);
        }

        Instantiate(hitFX, other.transform.position, other.transform.rotation);
        Destroy(gameObject);    
    }
}
