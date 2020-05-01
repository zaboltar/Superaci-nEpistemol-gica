using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    //public int startingLives;
    private int lifeCounter;
    private Text theTxt;
    public GameObject gameoverScreen;
    public PlayerCtrl player;
    public string mainMenu;
    public float waitAfterGameOver;

    void Start()
    {
        theTxt = GetComponent<Text>();
        lifeCounter = PlayerPrefs.GetInt("PlayerCurrentLives");
        player = FindObjectOfType<PlayerCtrl>();
    }

    void Update ()
    {
        
        if (lifeCounter < 0)
        {
            gameoverScreen.SetActive(true);
            player.gameObject.SetActive(false);
        }

        theTxt.text = "x " + lifeCounter;

        if (gameoverScreen.activeSelf)
        {
            waitAfterGameOver -= Time.deltaTime;

        }

        if (waitAfterGameOver < 0)
    {
        SceneManager.LoadScene(mainMenu);
    }


    }

    public void GiveLife()
    {
        lifeCounter++;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);
    }

    public void TakeLife()
    {
        lifeCounter--;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);
    }

}
