//\===========================================================================================================================================
//\ Filename: PlayerSpawnerScript.cs
//\ Author  : Michael Thomas
//\ Date    : 04/03/2019
//\ Brief   : Instantiates the player into the game world
//\===========================================================================================================================================

using UnityEngine;

public class PlayerSpawnerScript : MonoBehaviour {

    #region Public Variables

    public GameObject PlayerGameObject;

    #endregion


    #region Public Methods

    public void SpawnPlayer()
    {
        Instantiate(PlayerGameObject, gameObject.transform);
    }

    #endregion
}
