﻿using UnityEngine;

public class MainMenu : SimpleMenu<MainMenu>
{
    public void OnPlayPressed()
    {
        GameControllerScript gameScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
        gameScript.RestartGame();
        Hide();
        GameMenu.Show();
    }

    public void OnOptionsPressed()
    {
        OptionsMenu.Show();
    }

    public override void OnBackPressed()
    {
        Application.Quit();
    }
}