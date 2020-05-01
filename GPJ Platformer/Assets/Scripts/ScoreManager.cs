using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public Text text;

    void Start()
    {
        text = GetComponent<Text>();
        //score = 0;
        score = PlayerPrefs.GetInt("PlayerCurrentScore");
    }

    void Update ()
    {
        if (score < 0)
        score = 0;

        text.text = "" + score.ToString();
    }

    public static void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        PlayerPrefs.SetInt("PlayerCurrentScore", score);
    }

    public static void ResetPoints()
    {
        score = 0;
        PlayerPrefs.SetInt("PlayerCurrentScore", score);
    }
}
