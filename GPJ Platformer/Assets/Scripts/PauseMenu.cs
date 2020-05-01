using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string levelSelect;
    public string mainMenu;

    public bool isPaused;
    public GameObject pauseMenu;


    void Update ()
    {
        if (isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        } else 
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnPause();
        }
    }

    public void PauseUnPause()
    {
        isPaused = !isPaused;
    }

    public void SelectLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelSelect);
        
    }

    public void Resume()
    {
        isPaused = false;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenu);
    }
}
