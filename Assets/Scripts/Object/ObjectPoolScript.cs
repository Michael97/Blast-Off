//\===========================================================================================================================================
//\ Filename: ObjectPoolScript.cs
//\ Author  : Michael Thomas
//\ Date    : 04/03/2019
//\ Brief   : A script that handles object pooling via the means of deactivating and activating specific gameobjects.
//\===========================================================================================================================================

using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolScript : MonoBehaviour {

    #region Private Variables

    //Object that has been selected to spawn
    private GameObject SelectedObject;
    private Vector3 StartPosition;

    #endregion

    #region Public Variables

    //Pools of objects
    public List <GameObject> poolObjects;

    #endregion

    #region Public Methods

    //Called by another script to set the SelectedObject, this will call another function to start the checks to spawn the object
    public void SetObject(GameObject _Object, Vector3 startPosition)
    {
        SelectedObject = _Object;
        StartPosition = startPosition;

        CheckObjectPool();
    }
    
    //Empties the array
    public void EmptyArray()
    {
        poolObjects.Clear();
    }

    #endregion

    #region Private Methods

    //Function that checks to see if there are any objects in the pool that can be used, if not it will create a new one
    private void CheckObjectPool()
    {
        int x = 0;
        bool foundObject = false;

        foreach (GameObject _object in poolObjects)
        { 
            //if we found the right object and its inactive, then we can use it!
            if (_object.tag == SelectedObject.tag && _object.activeInHierarchy == false)
            {
                ActivateObject(x);
                foundObject = true;
                break;
            }
            x++;
        }

        //If there are no avaliable objects in the pool then we create a new one and activate it
        if (!foundObject)
        {
            CreateNewObject();
        }
    }

    //Activates the object, int _x being the index to use to find the object in the poolObjects list
    private void ActivateObject(int _x)
    {
        //find the object and set it true
        poolObjects[_x].gameObject.SetActive(true);
        SetPositionObject(_x);
    }

    //Sets the position of the desired object, int x being the index used to find it
    private void SetPositionObject(int x)
    {
        poolObjects[x].gameObject.transform.position = StartPosition;
    }

    private void CreateNewObject()
    {
        //Add new object to the inactivepoolobjects
        poolObjects.Add(Instantiate(SelectedObject, gameObject.transform));
        SetPositionObject(poolObjects.Count - 1);
    }

    #endregion
}
