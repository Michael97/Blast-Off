//\===========================================================================================================================================
//\ Filename: ObjectSpawnerScript.cs
//\ Author  : Michael Thomas
//\ Date    : 04/03/2019
//\ Brief   : A script that handles the spawning of objects in the scene using the Marsaglia Polar Method to generate completly new
//\           and unexpected objects for the player to navigate through based using the three sigma rule. We use object pooling to 
//\           optimise the performance of the game, if no object is avaliable then one will be made.
//\===========================================================================================================================================

using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    #region Public Variables

    //arrays for the gameobject prefabs used in the game
    public GameObject[] easyObstacles;
    public GameObject[] mediumObstacles;
    public GameObject[] hardObstacles;

    //ObjectPool script
    public ObjectPoolScript ObjectPoolScript_;

    public ZoneController ZoneScript;

    public int obstaclesLeft;

    #endregion


    #region Private Variables

    //arrays for the obstacles in each sigma
    private GameObject[] OneSigma;
    private GameObject[] TwoSigma;
    private GameObject[] ThreeSigma;

    //The next obstacle to be spawned
    private GameObject ChosenObstacle;

    //Static variables for the random num generator
    private static float r0;
    private static bool generate = true;

    public bool shouldSpawnObject;

    public float ObjectSpawnInterval;

    #endregion


    #region Public Methods

    //Run when the game level starts
    public void SpawnerStart()
    {
        shouldSpawnObject = true;

        //Call SpawnNewObject after 2 secs, every 5 secs
        InvokeRepeating("SpawnNewObject", 2.0f, ObjectSpawnInterval);

        SetLevelDifficulty(easyObstacles, mediumObstacles, hardObstacles);
    }

    //Cancels all invokes on this script
    public void CancelSpawner()
    {
        CancelInvoke("SpawnNewObject");
    }

    #endregion


    #region Private Methods

    //Choose and spawn the next object
    private void SpawnNewObject()
    {
        if (obstaclesLeft > 0 && shouldSpawnObject == true)
        {
            ThreeSigmaRule();
            ObjectPoolScript_.SetObject(ChosenObstacle, gameObject.transform.position);
            obstaclesLeft--;
        }
        else if (obstaclesLeft <= 0)
        {
            ZoneScript.NextZone();
            shouldSpawnObject = false;
        }
    }

    //Spawns the correct obstacle using the threesigma rule
    private void ThreeSigmaRule()
    {
        float num = MarsagliaNormalDistribution();

        bool chosen = false;

        do
        {
            if (num <= 1 && num >= -1)
            {
                ChosenObstacle = OneSigma[Random.Range(0, OneSigma.Length)];
                //Debug.Log("easy");
                chosen = true;
            }
            else if (num <= 2 && num >= -2)
            {
                ChosenObstacle = TwoSigma[Random.Range(0, TwoSigma.Length)];
                //Debug.Log("medium");
                chosen = true;
            }
            else if (num <= 3 && num >= -3)
            {
                ChosenObstacle = ThreeSigma[Random.Range(0, ThreeSigma.Length)];
                //Debug.Log("hard");
                chosen = true;
            }
            else
                num = MarsagliaNormalDistribution();
        }
        while (!chosen);

    }

    //Generates a random number with marsaglia normal distribution
    private static float MarsagliaNormalDistribution(float mean = 0f, float standardDev = 1f)
    {
        float u, v, s;

        generate = !generate;

        if (generate)
            return r0 * standardDev + mean;

        do
        {
            u = 2.0f * Random.value - 1.0f;
            v = 2.0f * Random.value - 1.0f;
            s = u * u + v * v;
        }
        while (s >= 1.0f || s == 0.0f);

        float fac = Mathf.Sqrt(-2.0f * Mathf.Log(s) / s);
        r0 = v * fac;

        return u * fac * standardDev + mean;

    }

    //Function to change the difficulty procedually.
    private void SetLevelDifficulty(GameObject[] highestSpawn, GameObject[] MediumSpawn, GameObject[] lowestSpawn)
    {
        OneSigma = highestSpawn;
        TwoSigma = MediumSpawn;
        ThreeSigma = lowestSpawn;
    }

    #endregion
}
