using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseButtonController : BaseMobileController
{
    public float m_horizontal_direction;
    public float m_speed = 1.0f;

    public override void Move()
    {
        base.Move();
        PlayerControllerScript.HortizontalDirection = m_horizontal_direction * m_speed;
    }

    public override void ResetMove()
    {
        base.ResetMove();
        PlayerControllerScript.HortizontalDirection = 0.0f;
    }
}
