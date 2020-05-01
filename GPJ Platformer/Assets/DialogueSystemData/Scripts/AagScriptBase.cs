using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AagScriptBase : MonoBehaviour
{
    public GameObject hint;
    public bool onRange = false;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("InZone");
            hint.gameObject.SetActive(true);
            onRange = true;
        }        
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("OutZone");
            hint.gameObject.SetActive(false);
            onRange = false;
        }        
    }
}
