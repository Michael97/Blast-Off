using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : SimpleMenu<DeathMenu>
{
    public Text CurrentScore;
    public Text HighScore;
    public GameObject Grade;

    public List<Sprite> GradeSprites;

    public HighscoresController HighscoresScript;
    public GameController GameScript;

    new void OnEnable()
    {
        GameScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        Grade = transform.Find("Grade").gameObject;
        if (GameScript.points < 100)
        {
            Grade.GetComponent<Image>().sprite = GradeSprites[1];
            Grade.GetComponent<Animator>().SetBool("GradeB", true);
        }
        else if (GameScript.points < 200)
        {
            Grade.GetComponent<Image>().sprite = GradeSprites[2];
            Grade.GetComponent<Animator>().SetBool("GradeA", true);
        }
        else
        {
            Grade.GetComponent<Image>().sprite = GradeSprites[0];
            Grade.GetComponent<Animator>().SetBool("GradeS", true);
        }

        HighscoresScript = GameObject.FindGameObjectWithTag("HighscoreController").GetComponent<HighscoresController>();

        CurrentScore = transform.Find("Score").GetComponent<Text>();
        HighScore = transform.Find("Highscore").GetComponent<Text>();

        HighScore.text = HighscoresScript.IsNewHighscore(GameScript.points).ToString();
        CurrentScore.text = GameScript.points.ToString();

       

        if (PlayerPrefs.HasKey("Money"))
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + GameScript.points);
        else
            PlayerPrefs.SetInt("Money", GameScript.points);
    }

    //This is the restart button.
    public override void OnBackPressed()
    {
        Grade.GetComponent<Image>().sprite = GradeSprites[3];
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
