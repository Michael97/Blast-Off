//\===========================================================================================================================================
//\ Filename: ObjectRotation.cs
//\ Author  : Michael Thomas
//\ Date    : 04/03/2019
//\ Brief   : This script chooses a random direction for an object to rotate in.
//\===========================================================================================================================================

using UnityEngine;

//Script to determine which wa a sprite will rotate. either clockwise or counter clockwise
public class ObjectRotation : MonoBehaviour {

    #region Private Variables

    private Vector3 rotationDirection;
    private int randomNum;

    #endregion


    #region Public Variables

    public float rotationSpeedMultplier;

    #endregion


    #region Private Methods

    private void Awake()
    {
        //Find a random number between 0 and 2
        randomNum = Random.Range(0, 2);
        
        if (randomNum == 1)
            //counterclockwise
            rotationDirection = Vector3.forward * rotationSpeedMultplier;
        else
            //clockwise
            rotationDirection = Vector3.back * rotationSpeedMultplier;

    }

    //Called every frame
    private void FixedUpdate () {
        transform.Rotate(rotationDirection);
    }

    #endregion
}
