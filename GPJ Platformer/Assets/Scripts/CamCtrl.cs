using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCtrl : MonoBehaviour
{
    public PlayerCtrl player;
    public bool isFollowing;
    public float xOffset;
    public float yOffset;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerCtrl>();

        isFollowing = true;
    }

    // Update is called once per frame
    void Update()
    {
        player = FindObjectOfType<PlayerCtrl>();
        if (isFollowing)
        {
            transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, -10f) ;
        }
    }
}
