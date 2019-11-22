//\===========================================================================================================================================
//\ Filename: AstroidSpawner.cs
//\ Author  : Michael Thomas
//\ Date    : 16/11/2019
//\ Brief   : 
//\===========================================================================================================================================

using System.Collections;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    #region Public Variables

    //ObjectPool script
    public ObjectPoolScript ObjectPoolScript_;

    //The next obstacle to be spawned
    public GameObject ChosenObstacle;

    #endregion

    public enum State
    {
        Passive = 0,
        Normal = 1,
        Aggressive = 2,
        Running = 3
    }

    public State state;

    #region Public Methods

    IEnumerator Start()
    {
        state = State.Passive;
        while (true)
        {
            switch (state)
            {
                case State.Passive:
                    CancelSpawner();
                    state = State.Running;
                    break;
                case State.Normal:
                    CancelSpawner();
                    InvokeRepeating("SpawnNewObject", 0.0f, 3.0f);
                    state = State.Running;
                    break;
                case State.Aggressive:
                    CancelSpawner();
                    InvokeRepeating("SpawnNewObject", 0.0f, 1.0f);
                    state = State.Running;
                    break;
                case State.Running:

                    break;
            }
            yield return 0;
        }
    }

    //Cancels all invokes on this script
    public void CancelSpawner()
    {
        CancelInvoke("SpawnNewObject");
    }

    #endregion


    #region Private Methods

    //Choose and spawn the next object
    private void SpawnNewObject()
    {
        Vector3 spawnPosition = new Vector3();
        spawnPosition.x = gameObject.transform.position.x;
        spawnPosition.y = gameObject.transform.position.y + Random.Range(-5.0f, 5.0f);
        spawnPosition.z = gameObject.transform.position.z;

        ObjectPoolScript_.SetObject(ChosenObstacle, spawnPosition);
    }
    
    #endregion
}
