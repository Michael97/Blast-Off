//\===========================================================================================================================================
//\ Filename: PlayerSpawnerScript.cs
//\ Author  : Michael Thomas
//\ Date    : 04/03/2019
//\ Brief   : Instantiates the player into the game world
//\===========================================================================================================================================

using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

    #region Public Variables

    public GameObject PlayerGameObject;
    public Item ChosenPlayerItem;

    #endregion


    #region Public Methods

    public void SpawnPlayer()
    {
        PlayerGameObject.GetComponent<SpriteRenderer>().sprite = ChosenPlayerItem.icon;
        PlayerGameObject.GetComponent<SpriteRenderer>().color = ChosenPlayerItem.color;

        Instantiate(PlayerGameObject, gameObject.transform);
    }

    #endregion
}
