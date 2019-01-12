using UnityEngine;

public class PauseMenu : SimpleMenu<PauseMenu>
{
    public override void OnBackPressed()
    {
        Time.timeScale = 1;
        Hide();
    }

    public void OnQuitPressed()
    {
        Hide();
        Destroy(gameObject); // This menu does not automatically destroy itself
        GameMenu.Hide();
        MainMenu.Show();
    }
}
