using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public GameObject CurrentPlanet;
    public GameObject PlanetPrefab;

    public void SpawnPlanet()
    {
        CurrentPlanet = Instantiate(PlanetPrefab, this.transform);
    }

    public void DeletePlanet()
    {
        //Debug.Log("delete");
        Destroy(CurrentPlanet);
    }

    public void SpeedOff()
    {
        CurrentPlanet.GetComponent<ObjectMovement>().Speed = 6.0f;
    }
}
