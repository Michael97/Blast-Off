//\===========================================================================================================================================
//\ Filename: DestoryTimerScript.cs
//\ Author  : Michael Thomas
//\ Date    : 04/03/2019
//\ Brief   : This script handles lifespan of objects in the scene, once their life has expired they are destroyed. 
//\===========================================================================================================================================

using UnityEngine;

public class DestoryTimer : MonoBehaviour {

    #region Public Variables

    public float DestoryAfterSeconds;

    #endregion


    #region Private Variables

    private float timerSeconds;

    #endregion


    #region Private Methods

    private void OnEnable()
    {
        timerSeconds = DestoryAfterSeconds;
        //Resets the pickup for the prefab
    }

    // Update is called once per frame
    private void FixedUpdate () {
        timerSeconds -= Time.deltaTime;
        if (timerSeconds < 0)
            Destroy(gameObject);
	}

    #endregion
}
