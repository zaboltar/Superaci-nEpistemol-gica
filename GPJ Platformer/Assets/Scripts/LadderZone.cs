﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderZone : MonoBehaviour
{
    private PlayerCtrl thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerCtrl>();
    }

  private void OnTriggerEnter2D(Collider2D other)
  {
      if (other.name == "Player")
      {
          thePlayer.onLadder = true;
      }
  }

    private void OnTriggerExit2D(Collider2D other)
  {
      if (other.name == "Player")
      {
          thePlayer.onLadder = false;
      }
  }
}
