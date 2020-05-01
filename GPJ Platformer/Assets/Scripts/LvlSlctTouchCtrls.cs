using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlSlctTouchCtrls : MonoBehaviour
{
    public LevelSelectManager lvlSlctMngr;
    // Start is called before the first frame update
    void Start()
    {
        lvlSlctMngr = FindObjectOfType<LevelSelectManager>();

        lvlSlctMngr.touchMode = true;
    }

    public void MoveLeft()
    {
        lvlSlctMngr.positionSelector -= 1;

         if (lvlSlctMngr.positionSelector < 0)
            {
                lvlSlctMngr.positionSelector = 0;
            }
    }

    public void MoveRight()
    {
        lvlSlctMngr.positionSelector += 1;

         if (lvlSlctMngr.positionSelector >= lvlSlctMngr.levelTags.Length)
            {
                lvlSlctMngr.positionSelector = lvlSlctMngr.levelTags.Length - 1;
            }

    }

    public void LoadLevel()
    {
        PlayerPrefs.SetInt("PlayerLevelSelectPosition", lvlSlctMngr.positionSelector);
        SceneManager.LoadScene(lvlSlctMngr.levelName[lvlSlctMngr.positionSelector]);
    }
}
