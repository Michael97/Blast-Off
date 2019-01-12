using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EntityScript : MonoBehaviour
{
    public ParticleSystem deadParticleSystem;

    public EntityStateScript.EntityState entityState;

    public string LevelLoad;

    private void Awake()
    {
        entityState = EntityStateScript.EntityState.Alive;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "Pickup")
            {
                Debug.Log("thisisit");
                collision.gameObject.GetComponent<PickupScript>().PickedUp();
            }
            else
                Dead();
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(LevelLoad);
    }

    private void Dead()
    {
        entityState = EntityStateScript.EntityState.Dead;

        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject.GetComponentInChildren<ParticleSystem>());


        Instantiate(deadParticleSystem, gameObject.transform);

        Invoke("RestartLevel", 5.0f);
    }
}

