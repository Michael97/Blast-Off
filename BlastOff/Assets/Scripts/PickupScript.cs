using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour {

    public int Points;

    public void OnEnable()
    {
        gameObject.SetActive(true);
    }

    public void PickedUp()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>().AddScore(Points);
        gameObject.SetActive(false);
    }
}
