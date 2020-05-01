using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startLevel;
    public string levelSelect;
    public string credtScene;
    public string howToPlay;

    public int playerLives;
    public int playerHealth;
    public string level1Tag;

    public void NewGame()
    {
        
        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);
        PlayerPrefs.SetInt("PlayerCurrentScore", 0);
        PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);
        PlayerPrefs.SetInt("PlayerMaxHealth", playerHealth);

        PlayerPrefs.SetInt(level1Tag, 1);

        PlayerPrefs.SetInt("PlayerLevelSelectPosition", 0);
        SceneManager.LoadScene(startLevel);
    }

    public void SelectLevel()
    {
        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);
        PlayerPrefs.SetInt("PlayerCurrentScore", 0);
        PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);
        PlayerPrefs.SetInt("PlayerMaxHealth", playerHealth);
        PlayerPrefs.SetInt(level1Tag, 1);

        if (!PlayerPrefs.HasKey("PlayerLevelSelectPosition"))
        {
            PlayerPrefs.SetInt("PlayerLevelSelectPosition", 0);
        }

        SceneManager.LoadScene(levelSelect);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetPlayerData()
    {
        PlayerPrefs.SetInt("PlayerLevelSelectPosition", 0);
        Debug.Log("Borrado");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene(howToPlay);
    }

    public void Credits()
    {
        SceneManager.LoadScene(credtScene);
    }

}
