//\===========================================================================================================================================
//\ Filename: EntityStateScript.cs
//\ Author  : Michael Thomas
//\ Date    : 04/03/2019
//\ Brief   : This script just has the dead/alive state for an entity
//\===========================================================================================================================================

using UnityEngine;

public class EntityStateScript : MonoBehaviour {

    public enum EntityState
    {
        Alive = 0,
        Dead = 1
    };

}
