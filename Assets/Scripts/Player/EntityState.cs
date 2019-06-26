//\===========================================================================================================================================
//\ Filename: EntityStateScript.cs
//\ Author  : Michael Thomas
//\ Date    : 04/03/2019
//\ Brief   : This script just has the dead/alive state for an entity
//\===========================================================================================================================================

using UnityEngine;

public class EntityState : MonoBehaviour {

    public enum State
    {
        Alive = 0,
        Dead = 1
    };

}
