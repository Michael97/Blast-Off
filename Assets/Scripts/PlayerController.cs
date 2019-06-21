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

    public GameObject JoystickGameObject;

    #endregion


    #region Private Variables

    private void Awake()
    {
        JoystickGameObject = GameObject.FindGameObjectWithTag("DynamicJoystick");
    }

    private void FixedUpdate()
    { 
        MoveDirection();
    }

    //Updates the position of the object
    private void MoveDirection()
    {
        float tempNum = JoystickGameObject.GetComponent<FloatingJoystick>().Vertical;

        if (tempNum == 0)
            tempNum = -0.4f;

        gameObject.transform.position += new Vector3(JoystickGameObject.GetComponent<FloatingJoystick>().Horizontal * movementSpeed * Time.deltaTime, tempNum * boosterSpeed * Time.deltaTime, gameObject.transform.position.z);
    }

    #endregion
}
