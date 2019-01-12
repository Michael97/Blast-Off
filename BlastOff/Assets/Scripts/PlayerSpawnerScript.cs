using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerScript : MonoBehaviour {


    public GameObject PlayerGameObject;

    public void SpawnPlayer()
    {
        Instantiate(PlayerGameObject, gameObject.transform);
    }
}
