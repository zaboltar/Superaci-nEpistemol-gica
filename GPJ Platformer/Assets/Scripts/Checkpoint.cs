using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator animator;
    public LvlManager lvlManager;
    // Start is called before the first frame update

    void Start()
    {
        lvlManager = FindObjectOfType<LvlManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if ( other.name == "Player")
        {
            lvlManager.currentCheckpoint = gameObject;
            //Debug.Log("New Chechpoint!");
            animator.SetBool("Open", true);
            GetComponent<AudioSource>().Play();
            GetComponent<CircleCollider2D>().enabled = false;
            
        }    
    }

}
