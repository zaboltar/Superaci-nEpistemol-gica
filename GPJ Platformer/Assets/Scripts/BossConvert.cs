using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossConvert : MonoBehaviour
{
    private Animator animator;
    public GameObject wallToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.name == "Player")
        {
            animator.SetTrigger("Convert");
        }
    }

    public void EndAnim()
    {
        Destroy(wallToDestroy.gameObject);
        Destroy(this);
        Destroy(gameObject);
    }
}
