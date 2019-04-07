//\===========================================================================================================================================
//\ Filename: PlayerControllerScript.cs
//\ Author  : Michael Thomas
//\ Date    : 04/03/2019
//\ Brief   : This script controls the player movement
//\===========================================================================================================================================

using UnityEngine;

public class PlayerControllerScript : EntityScript
{

    #region Public Variables

    public float movementSpeed;
    public float boosterSpeed;

    #endregion


    #region Private Variables

    private void FixedUpdate()
    { 
        MoveDirection();
    }

    //Updates the position of the object
    private void MoveDirection()
    {
        //Grabs the current vertical direction
        float tempNum = Input.GetAxis("Vertical");

        if (tempNum == 0)
            tempNum = -0.4f;

        gameObject.transform.position += new Vector3(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, tempNum * boosterSpeed * Time.deltaTime, gameObject.transform.position.z);
    }

    #endregion
}
