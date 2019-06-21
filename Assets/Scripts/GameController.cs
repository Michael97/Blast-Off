//\===========================================================================================================================================
//\ Filename: GameControllerScript.cs
//\ Author  : Michael Thomas
//\ Date    : 04/03/2019
//\ Brief   : This script handles the the level restart, holds the current points value and displays it on the screen, locks framerate.
//\===========================================================================================================================================

using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    #region Private Variables

    private int points;

    #endregion


    #region Public Variables

    public Text scoreText;

    public ZoneController ZoneScript;

    #endregion


    #region Public Methods

    public void RestartGame()
    {
        //Grab the current play and object controller
        GameObject currentPlayer = GameObject.FindGameObjectWithTag("Player");
        GameObject objectController = GameObject.FindGameObjectWithTag("ObjectController");

        //grab the amount of children there are in the object
        int children = objectController.transform.childCount;

        //If there is a player, then delete them
        if (currentPlayer != null)
            Destroy(currentPlayer);

        //Delete all the current child objects
        if (objectController.transform.childCount > 0)
            for (int i = 0; i < children; i++)
            {
                Destroy(objectController.transform.GetChild(i).gameObject);
            }

        //Empty the pool script
        objectController.GetComponent<ObjectPoolScript>().EmptyArray();

        //Cancel the spawning objects, then restart them
        objectController.GetComponent<ObjectSpawner>().CancelSpawner();

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

    // Use this for initialization
    private void Awake()
    {
        points = 0;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Application.targetFrameRate = 60;
    }

    //Called to update the UI score
    private void UpdateScore()
    {
        scoreText.text = "Points: " + points;
    }

    #endregion
}
