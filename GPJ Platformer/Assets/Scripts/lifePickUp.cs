using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifePickUp : MonoBehaviour
{
    private LifeManager lifeSystem;
    public AudioSource lifeSFX;
    void Start()
    {
        lifeSystem = FindObjectOfType<LifeManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            lifeSFX.Play();
            lifeSystem.GiveLife();
            Destroy(gameObject);
        }
    }
}
