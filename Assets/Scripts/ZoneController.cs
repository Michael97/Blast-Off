//\===========================================================================================================================================
//\ Filename: ZoneController.cs
//\ Author  : Michael Thomas
//\ Date    : 06/03/2019
//\ Brief   : A script that holds varaibles and functions relevent to the zone changing
//\===========================================================================================================================================

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class ZoneController : MonoBehaviour
{
    #region Public Variables
    public int ZoneLevel;
    public int BaseObstacleCount;

    public ColorController ColorScript;
    public ObjectSpawner ObjectSpawnerScript;

    public ParticleSystem[] ParticleSystems;

    public Text CompleteLevelTextObject;
    public ParticleSystem particlesystem;
    public TextManager ZoneCompleteText;

    public PlayerController PlayerControllerScript;

    public PlanetController PlanetControllerScript;

    public bool m_still_playing;

    #endregion


    #region Private Variables

    [SerializeField]
    private int zoneObstacleCount;

    //private float timer;

    public Timer timer;

    public bool nextZone;

    #endregion


    #region Private Methods


    private void ResetParticleSystems()
    {
        for (int i = 0; i < ParticleSystems.Length; i++)
        {
            ParticleSystems[i].GetComponent<NextZoneParticleEffect>().NextZoneStart();
        }
    }

    private void Awake()
    {
        timer = new Timer(0.5f);        
    }

    private void FixedUpdate()
    {
        //Null check 
        if (ZoneCompleteText != null)
        {
            //Update the instance
            ZoneCompleteText.Update();

            //Check to see if we still need the object
            if (!ZoneCompleteText.DisplayText && m_still_playing)
            {
                ZoneCompleteText = null; //Set to null, garbage collector kills this
                PlanetControllerScript.DeletePlanet();
                PlanetControllerScript.SpawnPlanet();
            }
        }

        if (nextZone)
        {
            if (timer.GetHasFinished() == true)
            {
                //Update the color 
                ColorScript.ChangeColor();

                ResetParticleSystems();
                
                nextZone = false;

                PlanetControllerScript.SpeedOff();

                string tempString = "Completed Level " + (ZoneLevel - 1);

                ZoneCompleteText = new TextManager(CompleteLevelTextObject,
                        particlesystem, tempString, 0.5f, 4.0f);
            }
            else
                timer.Update();

        }
    }


    #endregion


    #region Public Methods

    //Called when obstaclesLeft == 0
    public void NextZone()
    {
        if (!m_still_playing)
            return;

        AnalyticsEvent.LevelComplete(ZoneLevel);

        //Increase the zone level by one
        ZoneLevel++;

        //Increase the obstacle count by the new zone level
        zoneObstacleCount++;

        //Update the obstacles left 
        ObjectSpawnerScript.obstaclesLeft = zoneObstacleCount;
       
        nextZone = true;

        timer.ResetTimer();
        timer.SetEnabled(true);
    }

    public void ResetZone()
    {
        ZoneLevel = 1;

        zoneObstacleCount = BaseObstacleCount + ZoneLevel;

        //Update the obstacles left 
        ObjectSpawnerScript.obstaclesLeft = zoneObstacleCount;

        //Update the color 
        ColorScript.ChangeColor();

        if (PlanetControllerScript.CurrentPlanet != null)
            PlanetControllerScript.DeletePlanet();

        PlanetControllerScript.SpawnPlanet();

        //Start the particle systems
        for (int i = 0; i < ParticleSystems.Length; i++)
        {
            ParticleSystems[i].GetComponent<ColorScript>().ColorChangeParticle();
            ParticleSystems[i].Stop();
            ParticleSystems[i].Play();
        }

        nextZone = false;
       // Debug.Log("Reset Zone called");
        timer.ResetTimer();
        timer.SetEnabled(true);
        m_still_playing = true;
    }

    public void CancelZone()
    {
     //   Debug.Log("Cancel Zone called");
        timer.SetEnabled(false);
        m_still_playing = false;

        foreach (ParticleSystem ps in ParticleSystems)
        {
            ps.Stop();
        }
        PlanetControllerScript.DeletePlanet();

        //Null check 
        if (ZoneCompleteText != null)
            ZoneCompleteText.DisplayText = false;
    }

    #endregion
}
