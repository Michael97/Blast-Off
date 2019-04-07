//\===========================================================================================================================================
//\ Filename: ObjectMovementScript.cs
//\ Author  : Michael Thomas
//\ Date    : 04/03/2019
//\ Brief   : This script moves an object downwards in the game world endlessly
//\===========================================================================================================================================

using UnityEngine;

public class ObjectMovementScript : MonoBehaviour {

    #region Private Methods

    // Update is called once per frame
    void FixedUpdate () {
        //Move downwards
        transform.Translate(Vector3.down * Time.deltaTime);
    }

    #endregion
}
