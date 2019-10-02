using UnityEngine;
using UnityEngine.Analytics;

public class GameMenu : SimpleMenu<GameMenu>
{


    public override void OnBackPressed()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().StopGame();
        Hide();
        MainMenu.Show();
    }

    public void OnResetPressed()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().RestartGame();
    }

    public void OnDeath()
    {
        
        Hide();
        DeathMenu.Show();
    }
}
