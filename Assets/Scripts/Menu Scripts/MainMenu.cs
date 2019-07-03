﻿using UnityEngine;
using UnityEngine.UI;

public class MainMenu : SimpleMenu<MainMenu>
{
    private void Start()
    {
        GameObject.FindGameObjectWithTag("HighscoreNumber").GetComponent<Text>().text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void OnPlayPressed()
    {
        GameController gameScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gameScript.RestartGame();
        Hide();
        Time.timeScale = 1;
        GameMenu.Show();
    }

    public void OnOptionsPressed()
    {
        OptionsMenu.Show();
    }

    public void OnHighscoresClick()
    {
        HighscoresMenu.Show();
    }

    public override void OnBackPressed()
    {
        Application.Quit();
    }
}