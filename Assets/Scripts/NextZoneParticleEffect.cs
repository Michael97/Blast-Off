//\===========================================================================================================================================
//\ Filename: NextZoneParticleEffect.cs
//\ Author  : Michael Thomas
//\ Date    : 06/03/2019
//\ Brief   : A script that increases the speed and y scale of a particle system, giving the impression of speed. it also reverses this to slow down
//\===========================================================================================================================================

using UnityEngine;

public class NextZoneParticleEffect : MonoBehaviour
{
    #region Public Variables

    public ObjectSpawner ObjectSpawnerScript;
    

    #endregion


    #region Private Variables

    [SerializeField]
    private float yClampMin = 1;
    [SerializeField]
    private float yClampMax = 6;

    [SerializeField]
    private float speedClampMin = 1;
    [SerializeField]
    private float speedClampMax = 3;

    [SerializeField]
    private bool shouldIncrease = false;
    [SerializeField]
    private bool shouldDecrease = false;

    #endregion


    #region Public Methods

    public void Increase(float time)
    { 
        //So we are going to reach our target speed and y value after time seconds

        if (yClampMax > gameObject.transform.localScale.y)
            gameObject.transform.localScale = new Vector3(1.0f, gameObject.transform.localScale.y + ((yClampMax - yClampMin) / time) * Time.deltaTime, 1.0f);
        else // if we have reach peak size then we should decrease the size, speed and change the color
        {
            shouldIncrease = false;
            shouldDecrease = true;

            ObjectSpawnerScript.shouldSpawnObject = true;
            //Debug.Log("we getting somewhere");

            //Change the color of the particles after we finished boosting.
            GetComponent<ColorScript>().ColorChangeParticle();


        }

        var main = GetComponent<ParticleSystem>().main;

        if (speedClampMax > main.simulationSpeed)
            main.simulationSpeed += (speedClampMax - speedClampMin) / time * Time.deltaTime;
    }

    public void Decrease(float time)
    {
        //So we are going to reach our target speed and y value after time seconds

        var main = GetComponent<ParticleSystem>().main;

        if (yClampMin < gameObject.transform.localScale.y)
            gameObject.transform.localScale = new Vector3(1.0f, (yClampMax - yClampMin) / time * Time.deltaTime, 1.0f);
        else
        {
            shouldDecrease = false;
            gameObject.transform.localScale = new Vector3(1.0f, yClampMin, 1.0f);
            main.simulationSpeed = speedClampMin;
        }

        if (speedClampMin < main.simulationSpeed)
            main.simulationSpeed -= (speedClampMax - speedClampMin) / time * Time.deltaTime;
    }


    public void NextZoneStart()
    {
        shouldIncrease = true;
    }

    private void FixedUpdate()
    {
        if (shouldIncrease)
            Increase(4.0f);
        else if (shouldDecrease)
            Decrease(1.5f);
    }

    #endregion

}
