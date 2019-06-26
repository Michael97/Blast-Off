using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpButtonController : BaseButtonController
{
    public override void Move()
    {
        base.Move();
        PlayerControllerScript.VerticalDirection = 1.0f;
    }

    public override void ResetMove()
    {
        base.ResetMove();
        PlayerControllerScript.VerticalDirection = -0.5f;
    }
}
