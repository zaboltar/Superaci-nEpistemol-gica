using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public int healthToGive;
    public AudioSource healthSFX;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerCtrl>() == null)
        return;

        HealthManager.HurtPlayer(-healthToGive);
        healthSFX.Play();
        
        Destroy(gameObject);
    }
}
