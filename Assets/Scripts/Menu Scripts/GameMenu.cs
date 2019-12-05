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
        GameController GameScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        if (GameScript.DeathCount >= 0)
        {
            GameScript.DeathCount = 0;
            Hide();
            RewardedAdsMenu.Show();
            
            return;
        }

        GameScript.DeathCount++;

        Hide();
        DeathMenu.Show();
    }
}
