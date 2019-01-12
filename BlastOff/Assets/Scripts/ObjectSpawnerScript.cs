using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerScript : MonoBehaviour {

    public GameObject[] easyObstacles;
    public GameObject[] mediumObstacles;
    public GameObject[] hardObstacles;

    private GameObject[] OneSigma;
    private GameObject[] TwoSigma;
    private GameObject[] ThreeSigma;

    public ObjectPoolScript ObjectPoolScript_;

    private GameObject ChosenObstacle;

    private void Awake()
    {
        InvokeRepeating("SpawnNewObject", 2.0f, 5.0f);

        Invoke("MediumLevel", 120f);
        Invoke("HardLevel", 240f);

        EasyLevel();
    }

    private void SpawnNewObject()
    {
        ThreeSigmaRule();
        ObjectPoolScript_.SetObject(ChosenObstacle, gameObject.transform.position);
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
                ChosenObstacle = easyObstacles[Random.Range(0, OneSigma.Length - 1)];
                Debug.Log("easy");
                chosen = true;
            }
            else if (num <= 2 && num >= -2)
            {
                ChosenObstacle = mediumObstacles[Random.Range(0, TwoSigma.Length - 1)];
                Debug.Log("medium");
                chosen = true;
            }
            else if (num <= 3 && num >= -3)
            {
                ChosenObstacle = hardObstacles[Random.Range(0, ThreeSigma.Length - 1)];
                Debug.Log("hard");
                chosen = true;
            }
            else
                num = MarsagliaNormalDistribution();
        }
        while (!chosen);

    }


    static float r0;
    static bool generate = true;
    //Generates a random number with marsaglia normal distribution
    public static float MarsagliaNormalDistribution(float mean = 0f, float standardDev = 1f)
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

    //Functions to change the difficulty procedually.
    private void EasyLevel()
    {
        OneSigma = easyObstacles;
        TwoSigma = mediumObstacles;
        ThreeSigma = hardObstacles;
    }

    private void MediumLevel()
    {
        OneSigma = mediumObstacles;
        TwoSigma = easyObstacles;
        ThreeSigma = hardObstacles;
    }

    private void HardLevel()
    {
        OneSigma = hardObstacles;
        TwoSigma = mediumObstacles;
        ThreeSigma = easyObstacles;
    }

}
