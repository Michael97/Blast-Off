﻿using UnityEngine;

public class HighscoresController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }

    public int IsNewHighscore(int a_score)
    {
        if (a_score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", a_score);
        }
        return PlayerPrefs.GetInt("HighScore");
    }
}
