using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour {

    private Vector3 rotationDirection;
    private int randomNum;

    public float rotationSpeedMultplier;

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


    void FixedUpdate () {
        transform.Rotate(rotationDirection);
    }
}
