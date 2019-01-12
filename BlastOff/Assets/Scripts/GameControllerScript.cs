using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

    private int points;

    public Text scoreText;

	// Use this for initialization
	void Awake () {
        points = 0;
        Application.targetFrameRate = 60;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        UpdateScore();
        Application.targetFrameRate = 60;
    }

    public void RestartGame()
    {
        GameObject currentPlayer = GameObject.FindGameObjectWithTag("Player");
        GameObject objectController = GameObject.FindGameObjectWithTag("ObjectController");


        int children = objectController.transform.childCount;

        if (currentPlayer != null)
            Destroy(currentPlayer);

        if (objectController.transform.childCount > 0)
            for (int i = 0; i < children; i++)
            {
                Destroy(objectController.transform.GetChild(i).gameObject);
            }

        PlayerSpawnerScript playerSpawnerScript = GameObject.FindGameObjectWithTag("PlayerSpawner").GetComponent<PlayerSpawnerScript>();
        playerSpawnerScript.SpawnPlayer();


    }

    public void AddScore(int newPointsValue)
    {
        points += newPointsValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Points: " + points;
    }
}
