using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButtonController : BaseButtonController
{
    public override void Move()
    {
        base.Move();
        PlayerControllerScript.HortizontalDirection = 1.0f;
    }

    public override void ResetMove()
    {
        base.ResetMove();
        PlayerControllerScript.HortizontalDirection = 0.0f;
    }
}
