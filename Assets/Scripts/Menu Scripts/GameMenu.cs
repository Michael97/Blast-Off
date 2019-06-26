using UnityEngine;

public class GameMenu : SimpleMenu<GameMenu>
{
    public override void OnBackPressed()
    {
        Time.timeScale = 0;
        PauseMenu.Show();
    }

    public void OnDeath()
    {
        Time.timeScale = 0;
        DeathMenu.Show();
    }
}
