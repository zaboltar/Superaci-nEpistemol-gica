using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFinishedParticle : MonoBehaviour
{
    private ParticleSystem thisFX;

    // Start is called before the first frame update
    void Start()
    {
        thisFX = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!thisFX.isPlaying ) {Destroy(gameObject);}
        
            
        
    }

    void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }
}
