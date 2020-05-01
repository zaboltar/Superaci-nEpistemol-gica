using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxPlayerHealth;
    public static int playerHealth;
    //Text text;
    private LvlManager lvlmangr;
    public bool isDead;
    private LifeManager lifeSystem;
    private TimeManager theTime;
    public Slider healthBar;

    void Start ()
    {
        healthBar = GetComponent<Slider>();
        theTime = FindObjectOfType<TimeManager>();
        //text = GetComponent<Text>();
       // playerHealth = maxPlayerHealth;
        playerHealth = PlayerPrefs.GetInt("PlayerCurrentHealth");
        lvlmangr = FindObjectOfType<LvlManager>();
        lifeSystem = FindObjectOfType<LifeManager>();
        isDead = false ;


    }

    void Update ()
    {
        if (playerHealth <= 0 && !isDead)
        {
            lifeSystem.TakeLife();
            playerHealth = 0;
            lvlmangr.RespawnPlayer();
           // lifeSystem.TakeLife();
            isDead = true;
            theTime.ResetTime();
        }

        if (playerHealth > maxPlayerHealth)
        {
            playerHealth = maxPlayerHealth;
        }

        healthBar.value = playerHealth;
       // text.text = "" + playerHealth;
    }

    public static void HurtPlayer(int damageToGive)
    {
        playerHealth -= damageToGive;
        PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);
    } 

    public void FullHealth()
    {
        playerHealth = PlayerPrefs.GetInt("PlayerMaxHealth");
        PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);
    }

    public void KillPlayer()
    {
        playerHealth= 0;

    }
}
