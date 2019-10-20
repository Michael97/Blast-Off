using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{

    public GameState.GameStateEnum alive_state;

    /*
    public void OnEnumChange(GameState.GameStateEnum new_enum)
    {
        //if the new state is in the mainmenu and we are not already active
        if (new_enum == GameState.GameStateEnum.Main && this.gameObject.activeSelf == false)
        {
            this.gameObject.SetActive(true);
        }
        else
            this.gameObject.SetActive(false);
    }
    */
}
