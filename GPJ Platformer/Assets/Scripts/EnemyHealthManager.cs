using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int enemyHealth;
    public GameObject deathFX;
    public int pointsOnDeath;

    void Update ()
    {
        if (enemyHealth <= 0)
        {
            Instantiate(deathFX, transform.position, transform.rotation);
            ScoreManager.AddPoints(pointsOnDeath);
            Destroy(gameObject);
        }
    }

    public void GiveDamage(int damageToGive)
    {
        enemyHealth -= damageToGive;
        GetComponent<AudioSource>().Play();
    }
}
