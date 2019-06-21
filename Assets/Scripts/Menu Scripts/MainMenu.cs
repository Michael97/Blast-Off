using UnityEngine;

public class MainMenu : SimpleMenu<MainMenu>
{
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

    public override void OnBackPressed()
    {
        Application.Quit();
    }
}