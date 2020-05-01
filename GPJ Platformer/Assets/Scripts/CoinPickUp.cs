using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{

    public int pointsToAdd;
    public AudioSource coinSFX;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerCtrl>() == null)
        return;

        ScoreManager.AddPoints(pointsToAdd);
        coinSFX.Play();
        Destroy(gameObject);
    }

}
