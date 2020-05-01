using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public bool playerInZone;
    public string levelToLoad;
    public string levelTag;

    void Start ()
    {
        playerInZone = false;
    }

    void Update ()
    {
        if (Input.GetAxisRaw("Vertical") > 0 && playerInZone)
        {
            //Application.LoadLevel(levelToLoad);
            //SceneManager.LoadScene(levelToLoad);
            LoadLevel();
        }
    }

    public void LoadLevel()
    {
        PlayerPrefs.SetInt(levelTag, 1);
        SceneManager.LoadScene(levelToLoad);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInZone = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInZone = false;
        }
    }
}
