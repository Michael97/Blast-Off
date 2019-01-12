using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryTimerScript : MonoBehaviour {

    public float DestoryAfterSeconds;

    private float timerSeconds;

    private void OnEnable()
    {
        timerSeconds = DestoryAfterSeconds;
        //Resets the pickup for the prefab
        gameObject.transform.Find("Pickup").gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate () {
        timerSeconds -= Time.deltaTime;
        if (timerSeconds < 0)
            gameObject.SetActive(false);
	}
}
