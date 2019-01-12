using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovementScript : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(Vector3.down * Time.deltaTime);
    }
}
