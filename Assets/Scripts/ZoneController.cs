//\===========================================================================================================================================
//\ Filename: ZoneController.cs
//\ Author  : Michael Thomas
//\ Date    : 06/03/2019
//\ Brief   : A script that holds varaibles and functions relevent to the zone changing
//\===========================================================================================================================================

using UnityEngine;

public class ZoneController : MonoBehaviour
{
    #region Public Variables
    public int ZoneLevel;
    public int BaseObstacleCount;

    public ColorController ColorScript;
    public ObjectSpawner ObjectSpawnerScript;

    public ParticleSystem[] ParticleSystems;

    #endregion


    #region Private Variables

    [SerializeField]
    private int zoneObstacleCount;

    //private float timer;

    private Timer timer;

    [SerializeField]
    private bool nextZone;

    #endregion


    #region Private Methods


    private void ResetParticleSystems()
    {
        for (int i = 0; i < ParticleSystems.Length; i++)
        {
            //ParticleSystems[i].GetComponent<ColorScript>().ColorChangeParticle();
            ParticleSystems[i].GetComponent<NextZoneParticleEffect>().NextZoneStart();
        }
    }

    private void Awake()
    {
        //Start the particle systems
        for (int i = 0; i < ParticleSystems.Length; i++)
        {
            ParticleSystems[i].GetComponent<ColorScript>().ColorChangeParticle();
        }

        timer = new Timer(10.0f);
    }


    private void FixedUpdate()
    {
        if (nextZone)
        {
            timer.Update();

            if (timer.GetHasFinished() == true)
            {
                //Update the color 
                ColorScript.ChangeColor();

                ResetParticleSystems();
                
                nextZone = false;
            }
        }
    }


    #endregion


    #region Public Methods

    //Called when obstaclesLeft == 0
    public void NextZone()
    {
        //Increase the zone level by one
        ZoneLevel++;

        //Increase the obstacle count by the new zone level
        zoneObstacleCount++;

        //Update the obstacles left 
        ObjectSpawnerScript.obstaclesLeft = zoneObstacleCount;
       
        nextZone = true;

        timer.ResetTimer();
    }

    public void ResetZone()
    {
        ZoneLevel = 1;

        zoneObstacleCount = BaseObstacleCount + ZoneLevel;

        //Update the obstacles left 
        ObjectSpawnerScript.obstaclesLeft = zoneObstacleCount;

        //Update the color 
        ColorScript.ChangeColor();

        //Start the particle systems
        for (int i = 0; i < ParticleSystems.Length; i++)
        {
            ParticleSystems[i].GetComponent<ColorScript>().ColorChangeParticle();
        }

        nextZone = false;

        timer.ResetTimer();
    }

    #endregion
}
