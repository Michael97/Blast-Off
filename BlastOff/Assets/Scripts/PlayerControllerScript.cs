using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : EntityScript
{
    public float movementSpeed;
    public float boosterSpeed;

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


}
