using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour
{
    public int damageTogive;
    

    void Start ()
    {

    }

    void Update ()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            HealthManager.HurtPlayer(damageTogive);
            other.GetComponent<AudioSource>().Play();

            var player = other.GetComponent<PlayerCtrl>();
            player.knockBackCount = player.knockBackLenght;

            if (other.transform.position.x < transform.position.x)
            {
                player.knockFromRight = true;
            } else
            {
                player.knockFromRight = false;
            }
        }    
    }
}
