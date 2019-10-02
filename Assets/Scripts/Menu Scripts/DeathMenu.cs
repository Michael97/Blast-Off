using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : SimpleMenu<DeathMenu>
{
    public Text CurrentScore;
    public Text HighScore;
    public Text Grade;

    public HighscoresController HighscoresScript;
    public GameController GameScript;

    new void OnEnable()
    {
        HighscoresScript = GameObject.FindGameObjectWithTag("HighscoreController").GetComponent<HighscoresController>();
        GameScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        CurrentScore = transform.Find("Score").GetComponent<Text>();
        HighScore = transform.Find("Highscore").GetComponent<Text>();
        Grade = transform.Find("Grade").GetComponent<Text>();

        HighScore.text = HighscoresScript.IsNewHighscore(GameScript.points).ToString();
        CurrentScore.text = GameScript.points.ToString();
        Grade.text = "E";

        if (PlayerPrefs.HasKey("Money"))
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + GameScript.points);
        else
            PlayerPrefs.SetInt("Money", GameScript.points);
    }

    //This is the restart button.
    public override void OnBackPressed()
    {
        GameController gameScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        Time.timeScale = 1;
        Hide();
        GameMenu.Show();
        gameScript.RestartGame();
    }

    public void OnQuitPressed()
    {
        GameController gameScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        Hide();
        Destroy(gameObject); // This menu does not automatically destroy itself
        //GameMenu.Hide();
        MainMenu.Show();
        gameScript.StopGame();
    }
}
