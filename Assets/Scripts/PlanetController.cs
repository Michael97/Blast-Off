using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public GameObject CurrentPlanet;
    public List<Sprite> PlanetSprites;
    public GameObject PlanetGameObject;

    public void SpawnPlanet()
    {
        CurrentPlanet = Instantiate(PlanetGameObject, this.transform);

        CurrentPlanet.GetComponent<SpriteRenderer>().sprite = GetRandomSprite();

        CurrentPlanet.GetComponent<SetMaterialTint>().UpdateColor();
    }

    private Sprite GetRandomSprite()
    {
        if (PlanetSprites.Count > 1)
        {
            return PlanetSprites[Random.Range(0, PlanetSprites.Count)];
        }
        else
            return PlanetSprites[0];
    }

    public void DeletePlanet()
    {
        Destroy(CurrentPlanet);
    }

    public void SpeedOff()
    {
        CurrentPlanet.GetComponent<ObjectMovement>().Speed = 6.0f;
    }
}
