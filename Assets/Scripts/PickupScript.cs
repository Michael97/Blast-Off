//\===========================================================================================================================================
//\ Filename: PickupScript.cs
//\ Author  : Michael Thomas
//\ Date    : 04/03/2019
//\ Brief   : A script that handles the value of collectable objects, also handles adding points to total points on gamecontrollerscript
//\===========================================================================================================================================

using UnityEngine;

public class PickupScript : MonoBehaviour {

    #region Public Variables

    public int points;
    public ParticleSystem particleSystem;

    #endregion


    #region Public Methods

    public void OnEnable()
    {
        gameObject.SetActive(true);
        
    }

    public void PickedUp()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>().AddScore(points);
        Instantiate(particleSystem, this.gameObject.transform.position, this.gameObject.transform.rotation);
        gameObject.SetActive(false);
       
    }

    #endregion
}
