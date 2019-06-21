//\===========================================================================================================================================
//\ Filename: EntityScript.cs
//\ Author  : Michael Thomas
//\ Date    : 04/03/2019
//\ Brief   : This script holds the methods and variables used in an entities in this game, this is an abstract class as we never
//\           actually implement this as an object
//\===========================================================================================================================================

using UnityEngine;

abstract public class Entity : MonoBehaviour
{
    #region Public Variables

    public ParticleSystem deadParticleSystem;

    public EntityState.State entityState;

    #endregion


    #region Private Methods

    private void Awake()
    {
        entityState = EntityState.State.Alive;
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
            }
            //else the gameobject we collided with is something that should  kill us
            else
                Dead();
        }
    }

    //Called when we restart the level cause we dead
    private void RestartLevel()
    {
        GameController gameScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gameScript.RestartGame();
    }

    //Called when we dead
    private void Dead()
    {
        //Set the entity state to dead
        entityState = EntityState.State.Dead;
        
        //Disable the renderer and collider
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;

        //Destroy the particle tale on the object
        Destroy(gameObject.GetComponentInChildren<ParticleSystem>());

        //Instantiate the dead particle system at this location
        Instantiate(deadParticleSystem, gameObject.transform);

        //Call restartlevel in 5 secs
        Invoke("RestartLevel", 5.0f);
    }

    #endregion
}

