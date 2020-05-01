using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlManager : MonoBehaviour
{
    public GameObject currentCheckpoint;
    private PlayerCtrl player;
    public GameObject deathFX;
    public GameObject respawnFX;
    public float respawnDelay;
    public int pointsPenaltyOnDeath;
    private float gravityStore;
    private CamCtrl camCtrl;
    public HealthManager healthManager;


    void Start()
    {
        player = FindObjectOfType<PlayerCtrl>();
        camCtrl = FindObjectOfType<CamCtrl>();
        healthManager = FindObjectOfType<HealthManager>();
    }

  
    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }


    public IEnumerator RespawnPlayerCo()
    {
        Instantiate(deathFX, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;

        camCtrl.isFollowing = false ;

       // gravityStore = player.GetComponent<Rigidbody2D>().gravityScale;

        //player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        //player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ScoreManager.AddPoints(-pointsPenaltyOnDeath);

        Debug.Log("Player Respawned");

        yield return new WaitForSeconds (respawnDelay);

        //player.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
        player.transform.position = currentCheckpoint.transform.position;
        player.knockBackCount = 0;
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;

        healthManager.FullHealth();
        healthManager.isDead = false;

        camCtrl.isFollowing = true;
        Instantiate(respawnFX, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }

}
