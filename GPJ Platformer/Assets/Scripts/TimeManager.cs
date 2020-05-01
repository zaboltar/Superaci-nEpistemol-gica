using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float startingTime;
    private float countingTime;
    private Text textTime;
    private PauseMenu thePauseMenu;
    //public GameObject gameoverScreen;
    //public PlayerCtrl player;
    private HealthManager theHealth;


    // Start is called before the first frame update
    void Start()
    {
        theHealth = FindObjectOfType<HealthManager>();
        countingTime = startingTime;
        textTime = GetComponent<Text>();
        thePauseMenu = FindObjectOfType<PauseMenu>();
       //player = FindObjectOfType<PlayerCtrl>();
    }

    // Update is called once per frame
    void Update()
    {

        if (thePauseMenu.isPaused)
        {
            return;
        }

        countingTime -= Time.deltaTime;

        if (countingTime <= 0)
        {
           // gameoverScreen.SetActive(true);
           // player.gameObject.SetActive(false);
           theHealth.KillPlayer();
        }

        textTime.text = "" + Mathf.Round(countingTime);
    }

    public void ResetTime()
    {
        countingTime = startingTime;
    }
}
