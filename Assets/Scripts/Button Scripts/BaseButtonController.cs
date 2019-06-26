using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseButtonController : MonoBehaviour
{
    public PlayerController PlayerControllerScript;

    public void GrabPlayerControllerScript()
    {
        PlayerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public virtual void Move()
    {
        PlayerControllerScriptNullCheck();
    }

    public virtual void ResetMove()
    {
        PlayerControllerScriptNullCheck();
    }

    private void PlayerControllerScriptNullCheck()
    {
        if (PlayerControllerScript == null)
        {
            GrabPlayerControllerScript();
        }
    }
}
