using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlockOnContact : MonoBehaviour
{
    public GameObject explosionFX;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Destroyable")
        {
            Instantiate(explosionFX, other.transform.position, other.transform.rotation);
            
            Destroy(other.gameObject);
        }    
    }
}
