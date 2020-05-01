using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoltShooter : MonoBehaviour
{
    public float playerRange;
    public GameObject enemyBolt;
    public PlayerCtrl player;
    public Transform launchPoint;
    public float waitBtwShots;
    private float shotCounter;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerCtrl>();    
        shotCounter = waitBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        shotCounter -= Time.deltaTime;

        Debug.DrawLine(new Vector3(transform.position.x - playerRange, 
        transform.position.y, 
        transform.position.z), 
        new Vector3 (transform.position.x + playerRange, 
        transform.position.y, 
        transform.position.z));

        if (transform.localScale.x < 0 &&
         player.transform.position.x > transform.position.x &&
          player.transform.position.x < transform.position.x + playerRange &&
          shotCounter < 0)
        {
            Instantiate(enemyBolt, launchPoint.position, launchPoint.rotation);
            shotCounter = waitBtwShots;
        }

         if (transform.localScale.x > 0 &&
         player.transform.position.x < transform.position.x &&
          player.transform.position.x > transform.position.x - playerRange &&
          shotCounter < 0)
        {
            Instantiate(enemyBolt, launchPoint.position, launchPoint.rotation);
            shotCounter = waitBtwShots;
        }

    }
}
