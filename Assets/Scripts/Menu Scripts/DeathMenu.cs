using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : SimpleMenu<DeathMenu>
{
    public Text CurrentScore;
    public Text HighScore;
    public Text Grade;

    public HighscoresController HighscoresScript;
    public GameController GameScript;

    void OnEnable()
    {
        HighscoresScript = GameObject.FindGameObjectWithTag("HighscoreController").GetComponent<HighscoresController>();
        GameScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        CurrentScore = transform.Find("Score").GetComponent<Text>();
        HighScore = transform.Find("Highscore").GetComponent<Text>();
        Grade = transform.Find("Grade").GetComponent<Text>();

        HighScore.text = HighscoresScript.IsNewHighscore(GameScript.points).ToString();
        CurrentScore.text = GameScript.points.ToString();
        Grade.text = "E";
    }

    public override void OnBackPressed()
    {
        GameController gameScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gameScript.RestartGame();
        Time.timeScale = 1;
        Hide();
        GameMenu.Show();
    }

    public void OnQuitPressed()
    {
        Hide();
        Destroy(gameObject); // This menu does not automatically destroy itself
        GameMenu.Hide();
        MainMenu.Show();
    }
}
