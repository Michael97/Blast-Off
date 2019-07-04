using UnityEngine;

public class GameMenu : SimpleMenu<GameMenu>
{
    public override void OnBackPressed()
    {
        Hide();
        MainMenu.Show();
    }

    public void OnResetPressed()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().RestartGame();
    }

    public void OnDeath()
    {
        //Time.timeScale = 0;
        Hide();
        DeathMenu.Show();
    }
}
