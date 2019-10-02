//\===========================================================================================================================================
//\ Filename: GameControllerScript.cs
//\ Author  : Michael Thomas
//\ Date    : 04/03/2019
//\ Brief   : This script handles the the level restart, holds the current points value and displays it on the screen, locks framerate.
//\===========================================================================================================================================

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class GameController : MonoBehaviour {

    #region Private Variables

    public int points;

    #endregion


    #region Public Variables

    public Text scoreText;

    public ZoneController ZoneScript;

    public int DeathCount;
    public AdvertController AdvertScript;
    public PlanetController PlanetScript;


    public bool ShouldShowTutorial;
    public GameObject TutorialGameObject;

    #endregion


    #region Public Methods

    public void StopGame()
    {
        AnalyticsEvent.LevelQuit(ZoneScript.ZoneLevel);

        DeletePlayer();

        PlanetScript.DeletePlanet();

        GameObject objectController = GameObject.FindGameObjectWithTag("ObjectController");

        DeleteObjectStuff(objectController);
    }

    public void RestartGame()
    {
        AnalyticsEvent.GameStart();
        DeathCount++;
        
        if (DeathCount >= 3)
        {
            AdvertScript.ShowAd();
            DeathCount = 0;
        }

        if (ShouldShowTutorial == true)
        {
            TutorialGameObject.SetActive(true);
            ShouldShowTutorial = false;
        }

        DeletePlayer();
        PlanetScript.DeletePlanet();

        GameObject objectController = GameObject.FindGameObjectWithTag("ObjectController");

        DeleteObjectStuff(objectController);

        ZoneScript.ResetZone();

        //Start the spawning objects again
        objectController.GetComponent<ObjectSpawner>().SpawnerStart();

        //Respawn the player
        PlayerSpawner playerSpawnerScript = GameObject.FindGameObjectWithTag("PlayerSpawner").GetComponent<PlayerSpawner>();
        playerSpawnerScript.SpawnPlayer();

        //Reset the points
        points = 0;
        UpdateScore();
    }

    //When we collect a point, this is called
    public void AddScore(int newPointsValue)
    {
        points += newPointsValue;
        UpdateScore();
    }

    #endregion


    #region Private Methods

    private void DeletePlayer()
    {
        GameObject currentPlayer = GameObject.FindGameObjectWithTag("Player");

        //If there is a player, then delete them
        if (currentPlayer != null)
            Destroy(currentPlayer);
    }

    private void DeleteObjectStuff(GameObject a_objectController)
    {
        //grab the amount of children there are in the object
        int children = a_objectController.transform.childCount;

        DeletePlayer();

        //Delete all the current child objects
        if (a_objectController.transform.childCount > 0)
            for (int i = 0; i < children; i++)
            {
                Destroy(a_objectController.transform.GetChild(i).gameObject);
            }

        //Empty the pool script
        a_objectController.GetComponent<ObjectPoolScript>().EmptyArray();

        //Cancel the spawning objects, then restart them
        a_objectController.GetComponent<ObjectSpawner>().CancelSpawner();
    }

    // Use this for initialization
    private void Awake()
    {
        ShouldShowTutorial = true;
        points = 0;
    }


    //Called to update the UI score
    private void UpdateScore()
    {
        if (scoreText == null)
            scoreText = GameObject.FindGameObjectWithTag("Points").GetComponent<Text>();

        scoreText.text = "Points " + points;
    }

    #endregion
}
