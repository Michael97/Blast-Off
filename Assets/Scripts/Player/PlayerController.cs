//\===========================================================================================================================================
//\ Filename: PlayerControllerScript.cs
//\ Author  : Michael Thomas
//\ Date    : 04/03/2019
//\ Brief   : This script controls the player movement
//\===========================================================================================================================================

using UnityEngine;

public class PlayerController : Entity
{

    #region Public Variables

    public float movementSpeed;
    public float boosterSpeed;

    public float HortizontalDirection;
    public float VerticalDirection;

    #endregion


    #region Private Variables

    private void FixedUpdate()
    { 
        MoveDirection();
    }

    //Updates the position of the object
    private void MoveDirection()
    {
        gameObject.transform.position += new Vector3(HortizontalDirection * movementSpeed * Time.deltaTime, VerticalDirection * boosterSpeed * Time.deltaTime, gameObject.transform.position.z);
    }

    #endregion
}
