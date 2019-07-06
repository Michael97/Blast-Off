//\===========================================================================================================================================
//\ Filename: DisableTimerScript.cs
//\ Author  : Michael Thomas
//\ Date    : 04/03/2019
//\ Brief   : This script handles lifespan of objects in the scene, once their life has expired they are disabled. 
//\===========================================================================================================================================

using UnityEngine;

public class DisableTimer : MonoBehaviour
{

    #region Public Variables

    public float DisableAfterSeconds;

    #endregion


    #region Private Variables

    private float timerSeconds;

    #endregion


    #region Private Methods

    private void OnEnable()
    {
        timerSeconds = DisableAfterSeconds;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        timerSeconds -= Time.deltaTime;
        if (timerSeconds < 0)
            gameObject.SetActive(false);
    }

    #endregion
}