using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    private PlayerCtrl player;
    private LevelLoader lvlExit;
    private PauseMenu pauseMenu;
    
    void Start()
    {
        player = FindObjectOfType<PlayerCtrl>();
        lvlExit = FindObjectOfType<LevelLoader>();
        pauseMenu = FindObjectOfType<PauseMenu>();
    }

    public void LeftArrow ()
    {
        player.Move(-1f);
        Debug.Log("PressLeft confirmed");
    }

    public void RightArrow ()
    {
        player.Move(1f);
        Debug.Log("PressRight confirmed");
    }

    public void UnpressArrow()
    {
        player.Move(0f);
        Debug.Log("Unpressed CSM");
    }

    public void Kick()
    {
        player.Kick();
        Debug.Log("Suposed to be kicking");
    }

    public void ResetKick()
    {
        player.ResetKick();
        Debug.Log("Reseting Kick");
    }

    public void ShootSun()
    {
        player.ShootSun();
    }

    public void  Jump()
    {
        player.Jump();

        if (lvlExit.playerInZone)
        {
            lvlExit.LoadLevel();
        }
    }

    public void Pause ()
    {
        pauseMenu.PauseUnPause();
    }
    
}
