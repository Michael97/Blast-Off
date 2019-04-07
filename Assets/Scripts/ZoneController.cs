﻿//\===========================================================================================================================================
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

    public ColorController ColorScript;
    public ObjectSpawnerScript ObjectSpawnerScript;

    public ParticleSystem[] ParticleSystems;

    #endregion


    #region Private Variables

    [SerializeField]
    private int zoneObstacleCount;

    private float timer;
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
        //Update the color 
        //ColorScript.ChangeColor();

        //Start the particle systems
        for (int i = 0; i < ParticleSystems.Length; i++)
        {
            ParticleSystems[i].GetComponent<ColorScript>().ColorChangeParticle();
        }
    }


    private void FixedUpdate()
    {
        if (nextZone)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
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
        timer = 10.0f;
    }

    public void ResetZone()
    {
        ZoneLevel = 1;

        zoneObstacleCount = 11;

        //Update the obstacles left 
        ObjectSpawnerScript.obstaclesLeft = zoneObstacleCount;

        //Update the color 
        ColorScript.ChangeColor();

        //Start the particle systems
        for (int i = 0; i < ParticleSystems.Length; i++)
        {
            ParticleSystems[i].GetComponent<ColorScript>().ColorChangeParticle();
        }
    }

    #endregion
}