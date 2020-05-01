using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public LvlManager lvlManager;
    private LifeManager lifeSystem;
    // Start is called before the first frame update
    void Start()
    {
        lvlManager = FindObjectOfType<LvlManager>();
        lifeSystem = FindObjectOfType<LifeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if ( other.name == "Player")
        {
            lifeSystem.TakeLife();
            lvlManager.RespawnPlayer();
        }    
    }
}
