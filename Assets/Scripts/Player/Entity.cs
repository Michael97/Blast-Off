//\===========================================================================================================================================
//\ Filename: EntityScript.cs
//\ Author  : Michael Thomas
//\ Date    : 04/03/2019
//\ Brief   : This script holds the methods and variables used in an entities in this game, this is an abstract class as we never
//\           actually implement this as an object
//\===========================================================================================================================================

using UnityEngine;
using UnityEngine.Analytics;

abstract public class Entity : MonoBehaviour
{
    #region Public Variables

    public ParticleSystem deadParticleSystem;
    public GameObject PlayerTouchController;
    private GameObject playerTouchController;
    public EntityState.State entityState;

    #endregion


    #region Private Methods

    private void Awake()
    {
        entityState = EntityState.State.Alive;

        if (PlayerPrefs.GetString("ChosenControlScheme") == "Tap")
        {
            playerTouchController = Instantiate(PlayerTouchController, this.transform);
            playerTouchController.SetActive(true);
        }
        else
            gameObject.AddComponent<PlayerDragController>();
    }

    //Checks for collisions with pickups
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if there is a collision
        if (collision != null)
        {
            //if the collisions gameobjects tag == "pickup"
            if (collision.gameObject.tag == "Pickup")
            {
                //Call "PickedUp()" function in the collision gameobjects script
                collision.gameObject.GetComponent<Pickup>().PickedUp();
                //Camera.main.GetComponent<CameraShake>().shakeDuration = 0.01f;
            }
            //else the gameobject we collided with is something that should  kill us
            else
            {
                Dead();
                Camera.main.GetComponent<CameraShake>().shakeDuration = 0.05f;
            }
        }
    }

    //Called when we restart the level cause we dead
    private void EndLevel()
    {
        GameMenu gameMenu = GameObject.FindGameObjectWithTag("GameMenu").GetComponent<GameMenu>();

        if (gameMenu != null)
            gameMenu.OnDeath();

    }

    //Called when we dead
    private void Dead()
    {
        //Set the entity state to dead
        entityState = EntityState.State.Dead;

        if (PlayerPrefs.GetString("ChosenControlScheme") == "Tap")
            playerTouchController.SetActive(false);
        else
            Destroy(GetComponent<PlayerDragController>());

        Handheld.Vibrate();
        Handheld.Vibrate();

        //Disable the renderer and collider
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;

        //Destroy the particle tale on the object
        Destroy(gameObject.GetComponentInChildren<ParticleSystem>());

        //Instantiate the dead particle system at this location
        Instantiate(deadParticleSystem, gameObject.transform);

        GameObject.FindGameObjectWithTag("ObjectController").GetComponent<ObjectSpawner>().CancelSpawner();

        if (transform.GetComponentInParent<AudioSource>().enabled == true)
            transform.GetComponentInParent<AudioSource>().Play();

        //Call restartlevel in 0.4 secs
        Invoke("EndLevel", 0.4f);

        AnalyticsEvent.GameOver();
    }

    #endregion
}

